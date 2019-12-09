using Free.Pay.Core.Hosting;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Free.Pay.Wechatpay.Results
{
    public class TestWxResult : IEndpointResult
    {

        public async Task ExecuteAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=UTF-8";
            await context.Response.WriteAsync("微信支付成功!");
            await context.Response.Body.FlushAsync();
        }
    }
}
