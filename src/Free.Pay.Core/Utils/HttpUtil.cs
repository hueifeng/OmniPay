using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Free.Pay.Core.Utils
{
    /// <summary>
    ///     Http工具类
    /// </summary>
    public static class HttpUtil
    {
        #region 属性

        private static IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        ///     当前上下文
        /// </summary>
        public static HttpContext Current => _httpContextAccessor.HttpContext;
        /// <summary>
        ///     本地IP
        /// </summary>
        public static string LocalIpAddress
        {
            get
            {
                try
                {
                    var ipAddress = Current.Connection.LocalIpAddress;
                    return IPAddress.IsLoopback(ipAddress)
                        ? IPAddress.Loopback.ToString()
                        : ipAddress.MapToIPv4().ToString();
                }
                catch
                {
                    return IPAddress.Loopback.ToString();
                }
            }
        }
        /// <summary>
        ///     客户端IP
        /// </summary>
        public static string RemoteIpAddress
        {
            get
            {
                try
                {
                    var ipAddress = Current.Connection.RemoteIpAddress;
                    return IPAddress.IsLoopback(ipAddress)
                        ? IPAddress.Loopback.ToString()
                        : ipAddress.MapToIPv4().ToString();
                }
                catch
                {
                    return IPAddress.Loopback.ToString();
                }
            }
        }
        /// <summary>
        ///     请求类型
        /// </summary>
        public static string RequestType => Current.Request.Method;

        /// <summary>
        ///     表单
        /// </summary>
        public static IFormCollection Form => Current.Request.Form;
        /// <summary>
        ///     请求体
        /// </summary>
        public static Stream Body
        {
            get
            {
                var body = Current.Request.Body;
                try
                {
                    if (body.CanSeek)
                    {
                        body.Position = 0;
                    }
                }
                catch 
                {}

                return body;
            }
        }

        /// <summary>
        /// 用户代理
        /// </summary>
        public static string UserAgent => Current.Request.Headers["User-Agent"];

        /// <summary>
        /// 内容类型
        /// </summary>
        public static string ContentType => Current.Request.ContentType;

        /// <summary>
        /// 参数
        /// </summary>
        public static string QueryString => Current.Request.QueryString.ToString();


        #endregion

        #region 构造函数

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region 方法
        /// <summary>
        ///    输出内容
        /// </summary>
        /// <param name="text">内容</param>
        public static void Write(string text)
        {
            Current.Response.ContentType = "text/plain;charset=utf-8";
            Task.Run(async () => { await Current.Response.WriteAsync(text); })
                .GetAwaiter()
                .GetResult();
        }
        /// <summary>
        ///     Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Get(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            using var response = request.GetResponse();
            using var reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd().Trim();
        }

        /// <summary>
        /// 异步Post请求
        /// </summary>
        /// <param name="url">url</param>
        /// <returns></returns>
        public static async Task<string> GetAsync(string url)
        {
            return await Task.Run(() => Get(url));
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="data">数据</param>
        /// <param name="cert">证书</param>
        /// <returns></returns>
        public static string Post(string url, string data, X509Certificate2 cert = null)
        {
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback =
                        new RemoteCertificateValidationCallback(CheckValidationResult);
            }

            var dataByte = Encoding.UTF8.GetBytes(data);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            request.ContentLength = dataByte.Length;

            if (cert != null)
            {
                request.ClientCertificates.Add(cert);
            }

            using (var outStream = request.GetRequestStream())
            {
                outStream.Write(dataByte, 0, dataByte.Length);
            }

            using var response = (HttpWebResponse)request.GetResponse();
            using var reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd().Trim();
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        /// <summary>
        /// 异步Post请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="data">数据</param>
        /// <param name="cert">证书</param>
        /// <returns></returns>
        public static async Task<string> PostAsync(string url, string data, X509Certificate2 cert = null)
        {
            return await Task.Run(() => Post(url, data, cert));
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="url">url</param>
        /// <returns></returns>
        public static byte[] Download(string url)
        {
            using var webClient = new WebClient();
            return webClient.DownloadData(url);
        }

        /// <summary>
        /// 异步下载
        /// </summary>
        /// <param name="url">url</param>
        /// <returns></returns>
        public static async Task<byte[]> DownloadAsync(string url)
        {
            using var webClient = new WebClient();
            return await webClient.DownloadDataTaskAsync(url);
        }

        #endregion


    }
}
