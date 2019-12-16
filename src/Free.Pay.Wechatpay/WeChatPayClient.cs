using System.Threading.Tasks;

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
        public Task<T> ExecuteAsync<T>(T request)
        {
            throw new System.NotImplementedException();
        }

    }
}