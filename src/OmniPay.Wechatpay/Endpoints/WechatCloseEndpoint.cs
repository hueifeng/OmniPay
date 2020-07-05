using System.Net;
using Free.Pay.Core.Hosting;
using Free.Pay.Core.Results;
using Free.Pay.Wechatpay.Endpoints.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Free.Pay.Wechatpay.Endpoints
{
    public class WechatCloseEndpoint:IEndpointHandler
    {
        private readonly ILogger<WechatCloseEndpoint> _logger;
        private readonly IWeChatPayClient _client;

        public WechatCloseEndpoint(ILogger<WechatCloseEndpoint> logger,IWeChatPayClient client){
            this._logger=logger;
            this._client=client;
        }
        public IEndpointResult Process(HttpContext context)
        {
             _logger.LogDebug("Start WechatClose request");

            if (!HttpMethods.IsPost(context.Request.Method))
            {
                _logger.LogWarning("Invalid HTTP method for Close endpoint.");
                return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }
            _logger.LogTrace("End WechatClose request. result type: {0}", this?.GetType().ToString() ?? "-none-");
            return new CloseResult(_client);
        }
    }
}