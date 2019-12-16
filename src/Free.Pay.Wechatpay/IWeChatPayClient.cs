using Free.Pay.Core.Request;
using System.Threading.Tasks;

namespace Free.Pay.Wechatpay
{
    public interface IWeChatPayClient
    {
        /// <summary>
        ///     Execute WeChatPay API request 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<string> ExecuteAsync<TModel, TResponse>(BaseRequest<TModel, TResponse> request);

    }
}
