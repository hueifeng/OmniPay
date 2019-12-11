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
        Task<T> ExecuteAsync<T>(T request);

    }
}
