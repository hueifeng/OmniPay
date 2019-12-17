using Free.Pay.Core.Request;
using Free.Pay.Core.Utils;
using Free.Pay.Wechatpay.Response;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Free.Pay.Core.Exceptions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Free.Pay.Wechatpay
{
    public class WeChatPayClient : IWeChatPayClient
    {
        private readonly WeChatPayOptions _weChatPayOptions;
        private readonly ILogger<WeChatPayClient> _logger;
        public WeChatPayClient(IOptionsMonitor<WeChatPayOptions> weChatPayOptions, ILogger<WeChatPayClient> logger)
        {
            _weChatPayOptions = weChatPayOptions.CurrentValue;
            
            _logger = logger;

        }

        /// <summary>
        ///     Execute WeChatPay API request implementation
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TResponse> ExecuteAsync<TModel, TResponse>(BaseRequest<TModel, TResponse> request)
        {
            BuildParams(request);
            string result = await HttpUtil.PostAsync(request.RequestUrl, request.ToXml());
            request.FromXml(result);
            BaseResponse baseResponse = (BaseResponse)(object)request.ToObject<TResponse>();
            baseResponse.Raw = result;

            var sign = request.GetStringValue("sign");

            if (string.IsNullOrEmpty(sign))
            {
                _logger.LogError("Signature verification failed:{0}",result);
                throw new FreePayException("Signature verification failed.");
            }
            return (TResponse)(object)baseResponse;
        }


        private void BuildParams<TModel, TResponse>(BaseRequest<TModel, TResponse> request)
        {
            if (string.IsNullOrEmpty(_weChatPayOptions.AppId))
            {
                throw new FreePayException(nameof(_weChatPayOptions.AppId));
            }

            request.Add("appid", _weChatPayOptions.AppId);
            request.Add("mch_id", _weChatPayOptions.Key);
            request.Add("sign", request.GetSign());
            request.RequestUrl = _weChatPayOptions.BaseUrl + request.RequestUrl;
        }


    }
}