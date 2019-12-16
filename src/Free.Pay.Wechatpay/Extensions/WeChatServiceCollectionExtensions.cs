using Free.Pay.Core.Hosting;
using Free.Pay.Wechatpay;
using Free.Pay.Wechatpay.Endpoints;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WeChatServiceCollectionExtensions
    {
        public static IServiceCollection AddWeChatEndpoints(this IServiceCollection services) {
            services.AddTransient<IEndpointRouter, EndpointRouter>();
            services.AddSingleton<WechatScanPayEndpoint>();
            services.AddSingleton(new Endpoint("wechatScanPay", "/pay-api/Wechatpay/ScanPay", typeof(WechatScanPayEndpoint)));
            return services;
        }

        public static IServiceCollection AddWeChatPay(this IServiceCollection services,Action<WeChatPayOptions> action) {
            if (action!=null)
            {
                services.Configure(action);
            }
            services.AddSingleton<IWeChatPayClient, WeChatPayClient>();
            return services;
        }
    }
}
