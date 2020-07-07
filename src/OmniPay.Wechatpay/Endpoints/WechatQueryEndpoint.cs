using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OmniPay.Core.Hosting;
using OmniPay.Core.Results;
using OmniPay.Wechatpay.Endpoints.Result;

namespace OmniPay.Wechatpay.Endpoints
{
    public class WechatQueryEndpoint:IEndpointHandler
    {
        private readonly ILogger<WechatQueryEndpoint> _logger;
        private readonly IWeChatPayClient _client;

        public WechatQueryEndpoint(ILogger<WechatQueryEndpoint> logger,IWeChatPayClient client){
            this._logger=logger;
            this._client=client;
        }
        public IEndpointResult Process(HttpContext context)
        {
             _logger.LogDebug("Start WechatQuery request");

            if (!HttpMethods.IsPost(context.Request.Method))
            {
                _logger.LogWarning("Invalid HTTP method for PublicPay endpoint.");
                return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }
            _logger.LogTrace("End WechatQuery request. result type: {0}", this?.GetType().ToString() ?? "-none-");
            return new QueryResult(_client);
        }
    }
}