using System.Threading.Tasks;
using Free.Pay.Core.Hosting;
using Microsoft.AspNetCore.Http;
using Free.Pay.Core.Utils;
using System;
using Free.Pay.Wechatpay.Request;
using Free.Pay.Wechatpay.Domain;

namespace Free.Pay.Wechatpay.Endpoints.Result
{
    public class WapPayResult : IEndpointResult
    {
        private readonly IWeChatPayClient _client;
        public WapPayResult(IWeChatPayClient client){
            this._client=client;
        }
        public async Task ExecuteAsync(HttpContext context)
        {
            try
            {
                var body = (await context.Request.ReadFormAsync()).AsNameValueCollection();
                if (body?.Count==0)
                {
                    throw new ArgumentNullException(nameof(body));
                }
                var request = new WapPayRequest();
                request.AddParameters(new WapPayModel()
                {
                    Body =body.Get("Body"),
                    OutTradeNo = body.Get("Out_Trade_No"),
                    TotalFee =int.Parse(body.Get("Total_Amount"))
                });
                await context.Response.WriteAsync ((await _client.ExecuteAsync (request)).ToJson());
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync (ex.Message);
            }
            context.Response.ContentType = "application/json; charset=UTF-8";
            await context.Response.Body.FlushAsync ();
        }
    }
}