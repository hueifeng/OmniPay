using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Free.Pay.Core.Request;
using Free.Pay.Wechatpay.Response;

namespace Free.Pay.Wechatpay
{
    public class WeChatPayClient:IWeChatPayClient
    {
        /// <summary>
        ///     Execute WeChatPay API request implementation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<string> ExecuteAsync<TModel, TResponse>(BaseRequest<TModel, TResponse> request)
        {

            var dataByte = Encoding.UTF8.GetBytes(request.ToXml());
            var request1 = (HttpWebRequest)WebRequest.Create("https://api.mch.weixin.qq.com/pay/unifiedorder");
            request1.Method = "POST";
            request1.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            request1.ContentLength = dataByte.Length;

          
            using (var outStream = request1.GetRequestStream())
            {
                outStream.Write(dataByte, 0, dataByte.Length);
            }

            using var response = (HttpWebResponse)request1.GetResponse();
            using var reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd().Trim();

            return request.ToXml();
          
           // throw new System.NotImplementedException();
        }

    }
}