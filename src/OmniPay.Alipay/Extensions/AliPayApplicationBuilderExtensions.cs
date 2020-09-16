using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OmniPay.Alipay.Middleware;
using OmniPay.Core.Utils;

namespace OmniPay.Alipay.Extensions
{
    public static class AliPayApplicationBuilderExtensions
    {
        /// <summary>
        /// 使用OmniPay
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseAliOmniPay(this IApplicationBuilder app)
        {
            app.UseMiddleware<AliPayMiddleware>();
            //var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            //HttpUtil.Configure(httpContextAccessor);
            return app;
        }
    }
}
