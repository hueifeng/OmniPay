using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OmniPay.Core.Hosting;

namespace OmniPay.Wechatpay.Results
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
