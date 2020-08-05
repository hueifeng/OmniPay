using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OmniPay.Alipay.Endpoints.Result;
using OmniPay.Core.Hosting;
using OmniPay.Core.Results;
using System.Net;

namespace OmniPay.Alipay.Endpoints
{
    public class AliScanPayEndpoint : IEndpointHandler
    {
        private readonly ILogger<AliScanPayEndpoint> _logger;
        private readonly IAliPayClient _client;

        public AliScanPayEndpoint(ILogger<AliScanPayEndpoint> logger, IAliPayClient client)
        {
            this._logger = logger;
            this._client = client;
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
