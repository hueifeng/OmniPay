using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OmniPay.Core.Utils;
using OmniPay.Wechatpay.Middleware;

namespace OmniPay.Wechatpay.Extensions
{
    public static class WeChatPayApplicationBuilderExtensions
    {
        //public static IEndpointConventionBuilder UseWeChatPayEndpoints(this IEndpointRouteBuilder endpoints,string pattern) {
        //    var pipeline = endpoints.CreateApplicationBuilder()
        //         .UseMiddleware<WechatPayMiddleware>().Build();
        //    return endpoints.Map(pattern, pipeline).WithDisplayName("wechatpay") ;
        //}

        /// <summary>
        /// 使用OmniPay
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseOmniPay(this IApplicationBuilder app)
        {
            app.UseMiddleware<WechatPayMiddleware>();
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            HttpUtil.Configure(httpContextAccessor);
            return app;
        }
    }
}
