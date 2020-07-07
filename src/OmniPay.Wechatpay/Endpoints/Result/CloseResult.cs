using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OmniPay.Core.Hosting;
using OmniPay.Core.Utils;
using OmniPay.Wechatpay.Domain;
using OmniPay.Wechatpay.Request;

namespace OmniPay.Wechatpay.Endpoints.Result
{
    public class CloseResult : IEndpointResult
    {
        private readonly IWeChatPayClient _client;
        public CloseResult(IWeChatPayClient client){
            this._client=client;
        }
        public async Task ExecuteAsync(HttpContext context)
        {
            try
            {
                var body = (await context.Request.ReadFormAsync()).AsNameValueCollection();
                if (body?.Count == 0) {
                    throw new ArgumentNullException (nameof (body));
                }
                var request = new CloseRequest();
                request.AddParameters(new CloseModel()
                {
                    OutTradeNo = body.Get("Out_Trade_No")
                });
                await context.Response.WriteAsync ((await _client.ExecuteAsync (request)).ToJson());
            }
            catch (System.Exception ex)
            {
               context.Response.StatusCode = StatusCodes.Status500InternalServerError;
               await context.Response.WriteAsync (ex.Message);
            }
            context.Response.ContentType = "application/json; charset=UTF-8";
            await context.Response.Body.FlushAsync ();
        }
    }
}