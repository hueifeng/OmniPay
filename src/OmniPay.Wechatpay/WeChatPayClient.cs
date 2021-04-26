using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OmniPay.Core.Exceptions;
using OmniPay.Core.Request;
using OmniPay.Core.Utils;
using OmniPay.Wechatpay.Response;
using System.Threading.Tasks;

namespace OmniPay.Wechatpay
{
    public class WeChatPayClient : IWeChatPayClient
    {
        private readonly WeChatPayOptions _weChatPayOptions;
        private readonly ILogger<WeChatPayClient> _logger;
        private readonly IHttpHandler _httpHandler;

        public WeChatPayClient(IOptions<WeChatPayOptions> weChatPayOptions, ILogger<WeChatPayClient> logger,
            IHttpHandler httpHandler)
        {
            _weChatPayOptions = weChatPayOptions.Value;
            _logger = logger;
            _httpHandler = httpHandler;
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
            var result = await _httpHandler.PostAsync(request.RequestUrl, request.ToXml(), _weChatPayOptions.HttpClientName, null);
            request.FromXml(result);
            var baseResponse = (BaseResponse)(object)request.ToObject<TResponse>();
            baseResponse.Raw = result;
            var repSign = request.GetStringValue("sign");
            if (string.IsNullOrEmpty(repSign) && !CheckSign(request, repSign, _weChatPayOptions.Key))
            {
                _logger.LogError("Signature verification failed:{0}", result);
                throw new OmniPayException("Signature verification failed.");
            }
            return (TResponse)(object)baseResponse;
        }

        private void BuildParams<TModel, TResponse>(BaseRequest<TModel, TResponse> request)
        {
            if (string.IsNullOrEmpty(_weChatPayOptions.AppId))
            {
                throw new OmniPayException(nameof(_weChatPayOptions.AppId));
            }
            request.Add("appid", _weChatPayOptions.AppId);
            request.Add("mch_id", _weChatPayOptions.MchId);
            request.Add("notify_url", _weChatPayOptions.NotifyUrl);
            request.Execute();
            request.Add("sign", BuildSign(request, _weChatPayOptions.Key, request.GetStringValue("sign_type") == "HMAC-SHA256"));
            request.RequestUrl = _weChatPayOptions.BaseUrl + request.RequestUrl;
        }

        internal static string BuildSign<TModel, TResponse>(BaseRequest<TModel, TResponse> request, string key, bool isHMACSHA256 = false)
        {
            var data = string.Join("&", $"{request.ToUrl(false)}&key={key}");
            return isHMACSHA256 ? EncryptUtil.HMACSHA256(data, key) : EncryptUtil.MD5(data);
        }

        internal static bool CheckSign<TModel, TResponse>(BaseRequest<TModel, TResponse> request, string sign, string key)
        {
            return BuildSign(request, key) == sign;
        }

    }
}