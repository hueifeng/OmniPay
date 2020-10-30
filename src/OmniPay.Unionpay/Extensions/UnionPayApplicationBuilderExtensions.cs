using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OmniPay.Core.Utils;
using OmniPay.Unionpay.Middleware;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OmniPay.Unionpay.Extensions
{
    public static class UnionPayApplicationBuilderExtensions 
    {
        public static IApplicationBuilder UseUnionPay(this IApplicationBuilder app)
        {
            app.UseMiddleware<UnionPayMiddleware>();
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            HttpUtil.Configure(httpContextAccessor);
            return app;
        }
    }
}
