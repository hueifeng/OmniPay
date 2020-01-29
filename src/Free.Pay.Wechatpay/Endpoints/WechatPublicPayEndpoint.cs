using System.Net;
using Free.Pay.Core.Hosting;
using Free.Pay.Core.Results;
using Free.Pay.Wechatpay.Endpoints.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Free.Pay.Wechatpay.Endpoints
{
    public class WechatPublicPayEndpoint:IEndpointHandler
    {
         private readonly ILogger<WechatPublicPayEndpoint> _logger;
        private readonly IWeChatPayClient _client;

        public WechatPublicPayEndpoint(ILogger<WechatPublicPayEndpoint> logger,IWeChatPayClient client){
            this._logger=logger;
            this._client=client;
        }
        public IEndpointResult Process(HttpContext context)
        {
             _logger.LogDebug("Start WechatAppPay request");

            if (!HttpMethods.IsPost(context.Request.Method))
            {
                _logger.LogWarning("Invalid HTTP method for ScanPay endpoint.");
                return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }
            _logger.LogTrace("End WechatAppPay request. result type: {0}", this?.GetType().ToString() ?? "-none-");
            return new PublicPayResult(_client);
        }
    }
}