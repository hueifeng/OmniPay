using Free.Pay.Core.Hosting;
using Free.Pay.Core.Results;
using Free.Pay.Wechatpay.Domain;
using Free.Pay.Wechatpay.Endpoints.Result;
using Free.Pay.Wechatpay.Request;
using Free.Pay.Wechatpay.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Free.Pay.Wechatpay.Endpoints
{
    public class WechatScanPayEndpoint : IEndpointHandler
    {
        private readonly ILogger<WechatScanPayEndpoint> _logger;
        private readonly IWeChatPayClient _client;
        public WechatScanPayEndpoint(ILogger<WechatScanPayEndpoint> logger,IWeChatPayClient client) {
            this._logger = logger;
            this._client=client;
        }
        public IEndpointResult Process(HttpContext context)
        {
            _logger.LogDebug("Start WechatScanPay request");

            if (!HttpMethods.IsPost(context.Request.Method))
            {
                _logger.LogWarning("Invalid HTTP method for ScanPay endpoint.");
                return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }
            _logger.LogTrace("End WechatScanPay request. result type: {0}", this?.GetType().ToString() ?? "-none-");
            return new ScanPayResult(_client);

        }

    }
}
