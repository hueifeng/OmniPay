using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Http;
using OmniPay.Core.Utils;

namespace OmniPay.Core.Configuration.DependencyInjection
{
    public static class OmniPayServiceCollectionExtensions
    {
        public static IServiceCollection AddOmniPayService(this IServiceCollection services, Action<OmniPayBuilder> builder)
        {
            //自动API将放到下一个里程碑计划中
            //services.AddTransient<IEndpointRouter, EndpointRouter>();
            //services.AddSingleton<DiscoveryEndpoint>();
            //services.AddSingleton(new Endpoint("OmniPay", "/.well-known/openpay-configuration", typeof(DiscoveryEndpoint)));
            //var httpContextAccessor = services.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            //HttpUtil.Configure(httpContextAccessor);
            services.AddTransient<IHttpHandler, HttpHandler>();
            var omniPayBuilder = new OmniPayBuilder(services);
            builder(omniPayBuilder);
            return services;
        }
    }
}
