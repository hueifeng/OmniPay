using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OmniPay.Core.Utils
{
    public interface IHttpHandler
    {
        /// <summary>
        ///     返回HttpClient
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        HttpClient CreateHttpClient(string? name = null);

        /// <summary>
        ///    异步GET请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="options"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string url, JsonSerializerOptions? options = null, params (string, object)[] headers);

        /// <summary>
        ///     异步POST请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <param name="options"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<string> PostAsync(string url, object request, JsonSerializerOptions options = null, params (string, object)[] headers);


        /// <summary>
        ///     异步POST请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <param name="logicalName"></param>
        /// <param name="options"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<string> PostAsync(string url, string request, string logicalName, JsonSerializerOptions options = null, params (string, object)[] headers);
    }
}
