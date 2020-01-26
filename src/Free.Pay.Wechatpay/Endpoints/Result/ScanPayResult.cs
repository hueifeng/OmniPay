using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Free.Pay.Core.Hosting;
using Free.Pay.Wechatpay.Domain;
using Free.Pay.Wechatpay.Request;
using Microsoft.AspNetCore.Http;
using Free.Pay.Core.Utils;

namespace Free.Pay.Wechatpay.Endpoints.Result {
    public class ScanPayResult : IEndpointResult {
        private readonly IWeChatPayClient _client;

        public ScanPayResult (IWeChatPayClient client) {
            this._client = client;
        }
        public async Task ExecuteAsync (HttpContext context) {
            try {
                var body = await context.Request.ReadFormAsync ();
                if (body?.Count == 0) {
                    throw new ArgumentNullException (nameof (body));
                }
                var request = new ScanPayRequest ();
                request.AddParameters (new ScanPayModel () {
                        Body = body["Body"],
                        OutTradeNo = body["Out_Trade_No"],
                        TotalFee = int.Parse (body["Total_Amount"])
                });
                await context.Response.WriteAsync ((await _client.ExecuteAsync (request)).ToJson());
            } catch (System.Exception ex) {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync (ex.Message);
            }
            context.Response.ContentType = "application/json; charset=UTF-8";
            await context.Response.Body.FlushAsync ();
        }
    }
}