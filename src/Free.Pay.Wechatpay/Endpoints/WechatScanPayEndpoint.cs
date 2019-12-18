using Free.Pay.Core.Hosting;
using Free.Pay.Core.Results;
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
        public WechatScanPayEndpoint(ILogger<WechatScanPayEndpoint> logger) {
            this._logger = logger;
        }
        public IEndpointResult Process(HttpContext context)
        {
            if (!HttpMethods.IsPost(context.Request.Method))
            {
                _logger.LogWarning("Invalid HTTP method for ScanPay endpoint.");
                return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }
            return new TestWxResult();
        }

    }
}
