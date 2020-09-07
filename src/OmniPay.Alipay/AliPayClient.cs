using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OmniPay.Alipay.Response;
using OmniPay.Core.Exceptions;
using OmniPay.Core.Request;
using OmniPay.Core.Utils;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OmniPay.Alipay
{
    public class AliPayClient : IAliPayClient
    {
        private readonly AlipayOptions _alipayOptions;
        private readonly ILogger<AliPayClient> _logger;

        public AliPayClient(IOptions<AlipayOptions> alioptions, ILogger<AliPayClient> logger)
        {
            this._alipayOptions = alioptions.Value;
            this._logger = logger;
        }

        /// <summary>
        ///     Execute AliPay API request implementation
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TResponse> ExecuteAsync<TModel, TResponse>(BaseRequest<TModel, TResponse> request)
        {
            BuildParams(request);
            string result = await HttpUtil.PostAsync("https://openapi.alipaydev.com" + request.RequestUrl, request.ToUrl());
            var jObject = JObject.Parse(result);
            var jToken = jObject.First.First;
            //baseResponse.Raw = result;
            var baseResponse = (BaseResponse)(object)jToken.ToObject<TResponse>();
            return (TResponse)(object)baseResponse;
        }

        private void BuildParams<TModel, TResponse>(BaseRequest<TModel, TResponse> request)
        {
            if (string.IsNullOrEmpty(_alipayOptions.AppId))
            {
                throw new FreePayException(nameof(_alipayOptions.AppId));
            }
            request.Add("app_id", _alipayOptions.AppId);
            request.Add("format", _alipayOptions.Format);
            request.Add("timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            request.Add("sign_type", _alipayOptions.SignType);
            request.Add("charset", _alipayOptions.Charset);
            request.Add("version", "1.0");
            request.Add("biz_content", request.ToStringCaseObj(request).ToJson());
            request.Add("sign", EncryptUtil.RSA(request.ToUrl(false), _alipayOptions.PrivateKey, _alipayOptions.SignType));
            request.RequestUrl = _alipayOptions.BaseUrl + request.RequestUrl;
        }



    }
}
