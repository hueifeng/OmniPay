using System.Threading.Tasks;
using OmniPay.Core.Request;

namespace OmniPay.Wechatpay
{
    public interface IWeChatPayClient
    {
        /// <summary>
        ///     Execute WeChatPay API request 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<TResponse> ExecuteAsync<TModel, TResponse>(BaseRequest<TModel, TResponse> request);

    }
}
