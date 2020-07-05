using System.Net;
using Free.Pay.Core.Hosting;
using Free.Pay.Core.Results;
using Free.Pay.Wechatpay.Endpoints.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Free.Pay.Wechatpay.Endpoints
{
    public class WechatAppletPayEndpoint : IEndpointHandler
    {
        private readonly ILogger<WechatAppletPayEndpoint> _logger;
        private readonly IWeChatPayClient _client;

        public WechatAppletPayEndpoint(ILogger<WechatAppletPayEndpoint> logger,IWeChatPayClient client){
            this._logger=logger;
            this._client=client;
        }
        public IEndpointResult Process(HttpContext context)
        {
             _logger.LogDebug("Start WechatAppletPay request");

            if (!HttpMethods.IsPost(context.Request.Method))
            {
                _logger.LogWarning("Invalid HTTP method for AppletPay endpoint.");
                return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }
            _logger.LogTrace("End WechatAppletPay request. result type: {0}", this?.GetType().ToString() ?? "-none-");
            return new AppletPayResult(_client);
        }
    }
}