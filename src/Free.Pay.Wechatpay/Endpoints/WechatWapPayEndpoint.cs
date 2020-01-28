using System.Net;
using Free.Pay.Core.Hosting;
using Free.Pay.Core.Results;
using Free.Pay.Wechatpay.Endpoints.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Free.Pay.Wechatpay.Endpoints
{
    public class WechatWapPayEndpoint : IEndpointHandler
    {
        private readonly ILogger<WechatWapPayEndpoint> _logger;
        private readonly IWeChatPayClient _client;
        public WechatWapPayEndpoint(ILogger<WechatWapPayEndpoint> logger,IWeChatPayClient client){
            this._logger=logger;
            this._client=client;
        }
        public IEndpointResult Process(HttpContext context)
        {
            _logger.LogDebug("Start WechatWapPay request");
            if (!HttpMethods.IsPost(context.Request.Method))
            {
                _logger.LogWarning("Invalid HTTP method for ScanPay endpoint.");
                return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }
             _logger.LogTrace("End WechatWapPay request. result type: {0}", this?.GetType().ToString() ?? "-none-");
           return new WapPayResult(_client);
        }
    }
}