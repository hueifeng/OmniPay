using Free.Pay.Core.Utils;
using Free.Pay.Wechatpay;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder
{
    public static class WeChatPayApplicationBuilderExtensions
    { 
        //public static IEndpointConventionBuilder UseWeChatPayEndpoints(this IEndpointRouteBuilder endpoints,string pattern) {
        //    var pipeline = endpoints.CreateApplicationBuilder()
        //         .UseMiddleware<WechatPayMiddleware>().Build();
        //    return endpoints.Map(pattern, pipeline).WithDisplayName("wechatpay") ;
        //}

        /// <summary>
        /// 使用FreePay
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseFreePay(this IApplicationBuilder app)
        {
            app.UseMiddleware<WechatPayMiddleware>();
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            HttpUtil.Configure(httpContextAccessor);
            return app;
        }
    }
}
