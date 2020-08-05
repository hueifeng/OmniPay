using OmniPay.Core.Request;
using System.Threading.Tasks;

namespace OmniPay.Alipay
{
    public interface IAliPayClient
    {
        /// <summary>
        ///     Execute AliPay API request
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<TResponse> ExecuteAsync<TModel, TResponse>(BaseRequest<TModel, TResponse> request);
    }
}
