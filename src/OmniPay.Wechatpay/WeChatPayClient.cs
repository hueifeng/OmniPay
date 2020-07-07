using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OmniPay.Core.Exceptions;
using OmniPay.Core.Request;
using OmniPay.Core.Utils;
using OmniPay.Wechatpay.Response;
using OmniPay.Wechatpay.Utils;

namespace OmniPay.Wechatpay
{
    public class WeChatPayClient : IWeChatPayClient
    {
        private readonly WeChatPayOptions _weChatPayOptions;
        private readonly ILogger<WeChatPayClient> _logger;

        public WeChatPayClient(IOptions<WeChatPayOptions> weChatPayOptions, ILogger<WeChatPayClient> logger)
        {
            _weChatPayOptions = weChatPayOptions.Value;
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
            //var reqsign= request.GetStringValue("sign");
            string result = await HttpUtil.PostAsync(request.RequestUrl, request.ToXml());
            request.FromXml(result);
            var baseResponse = (BaseResponse)(object)request.ToObject<TResponse>();
            baseResponse.Raw = result;
            var repsign = request.GetStringValue("sign");
            if (string.IsNullOrEmpty(repsign) &&!SignatureUtil.VerifyData(request,repsign))
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
            request.Add("notify_url",_weChatPayOptions.NotifyUrl);
            request.Execute();
            request.Add("sign", request.GetSign());
            request.RequestUrl = _weChatPayOptions.BaseUrl + request.RequestUrl;
        }

    }
}