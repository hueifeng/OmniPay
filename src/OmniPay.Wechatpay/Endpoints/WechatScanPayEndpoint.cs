using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OmniPay.Core.Hosting;
using OmniPay.Core.Results;
using OmniPay.Wechatpay.Endpoints.Result;
using OmniPay.Wechatpay.Validation;

namespace OmniPay.Wechatpay.Endpoints
{
    public class WechatScanPayEndpoint : IEndpointHandler
    {
        private readonly ILogger<WechatScanPayEndpoint> _logger;
        private readonly IWeChatPayClient _client;

        public WechatScanPayEndpoint(ILogger<WechatScanPayEndpoint> logger, IWeChatPayClient client)
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

            //var validateResult = _validator.ValidateAsync(context).GetAwaiter().GetResult();
            //if (validateResult.IsError)
            //{
            //    return Error(validateResult.Error);
            //}
            _logger.LogTrace("End WechatScanPay request. result type: {0}", this?.GetType().ToString() ?? "-none-");
            return new ScanPayResult(_client);
        }

        private IEndpointResult Error(string error, string description = null)
        {
            return new ProccessErrorResult(error, description);
        }

    }
}
