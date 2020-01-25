using System.Threading.Tasks;
using Free.Pay.Core.Hosting;
using Free.Pay.Wechatpay.Domain;
using Free.Pay.Wechatpay.Request;
using Microsoft.AspNetCore.Http;

namespace Free.Pay.Wechatpay.Endpoints.Result
{
    public class ScanPayResult : IEndpointResult
    {
        private readonly IWeChatPayClient _client;

        public ScanPayResult(IWeChatPayClient client){
            this._client=client;
        }
        public async Task ExecuteAsync(HttpContext context)
        {
             var body = await context.Request.ReadFormAsync();
             if (body!=null)
             {
                var request = new ScanPayRequest();
                request.AddParameters(new ScanPayModel()
                {
                    Body =body["Body"],
                    OutTradeNo = body["Out_Trade_No"],
                    TotalFee = int.Parse(body["Total_Amount"])
                });
                 context.Response.ContentType = "application/json; charset=UTF-8";
                await context.Response.WriteAsync((await _client.ExecuteAsync(request)).ToString());
                await context.Response.Body.FlushAsync();
               // return await _client.ExecuteAsync(request);
             }

        }
    }
}