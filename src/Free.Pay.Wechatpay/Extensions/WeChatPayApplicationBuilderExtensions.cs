using Free.Pay.Wechatpay;
using Microsoft.AspNetCore.Routing;

namespace Microsoft.AspNetCore.Builder
{
    public static class WeChatPayApplicationBuilderExtensions
    {
        public static IEndpointConventionBuilder UseWeChatPay(this IEndpointRouteBuilder endpoints) {
            var pipeline = endpoints.CreateApplicationBuilder()
                 .UseMiddleware<WechatPayMiddleware>().Build();
            return endpoints.Map("/pay-api/{controller}/{action}", pipeline).WithDisplayName("wechatpay") ;
        }
    }
}
