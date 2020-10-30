using System;
using Microsoft.Extensions.DependencyInjection;
using OmniPay.Alipay.Endpoints;
using OmniPay.Core.Hosting;

namespace OmniPay.Alipay.Extensions
{
    public static class AlipayServiceCollectionExtensions
    {
        public static IServiceCollection AddAliPay(this IServiceCollection services, Action<AlipayOptions> action)
        {
            //services.AddTransient<IEndpointRouter, EndpointRouter>();
            //services.AddSingleton<AliScanPayEndpoint>();
            //services.AddSingleton(new Endpoint("aliScanPay", "/pay-api/alipay/ScanPay", typeof(AliScanPayEndpoint)));
            return services.AddAliServices(action);
        }

        private static IServiceCollection AddAliServices(this IServiceCollection services, Action<AlipayOptions> action)
        {
            if (action != null)
            {
                services.Configure<AlipayOptions>(action.Invoke);
            }
            services.AddSingleton<IAliPayClient, AliPayClient>();
            return services;
        }
    }
}
