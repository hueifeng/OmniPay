using Microsoft.AspNetCore.Http;
using OmniPay.Core.Hosting;
using System;
using OmniPay.Core.Utils;
using System.Threading.Tasks;
using OmniPay.Alipay.Request;
using OmniPay.Alipay.Domain;

namespace OmniPay.Alipay.Endpoints.Result
{
    public class ScanPayResult : IEndpointResult
    {
        private readonly IAliPayClient _client;

        public ScanPayResult(IAliPayClient client)
        {
            this._client = client;
        }

        public async Task ExecuteAsync(HttpContext context)
        {
            try
            {
                var body = (await context.Request.ReadFormAsync()).AsNameValueCollection();
                if (body?.Count == 0)
                {
                    throw new ArgumentNullException(nameof(body));
                }
                var request = new ScanPayRequest();
                request.AddParameters(new ScanPayModel()
                {
                    Body = body.Get("Body"),
                    OutTradeNo = body.Get("Out_Trade_No"),
                    TotalAmount = double.Parse(body.Get("Total_Amount")),
                    Subject = body.Get("Subject")
                });
                await context.Response.WriteAsync((await _client.ExecuteAsync(request)).ToJson());
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(ex.Message);
            }
            context.Response.ContentType = "application/json; charset=UTF-8";
            await context.Response.Body.FlushAsync();
        }
    }
}
