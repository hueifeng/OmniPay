using Free.Pay.Core.Hosting;
using Free.Pay.Wechatpay;
using Free.Pay.Wechatpay.Endpoints;
using System;
using Microsoft.AspNetCore.Http;
using Endpoint = Free.Pay.Core.Hosting.Endpoint;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WeChatServiceCollectionExtensions
    {
        public static IServiceCollection AddWeChatEndpoints(this IServiceCollection services) {
            services.AddTransient<IEndpointRouter, EndpointRouter>();
            services.AddSingleton<WechatScanPayEndpoint>();
            services.AddSingleton<WechatWapPayEndpoint>();
            services.AddSingleton(new Endpoint("wechatScanPay", "/pay-api/Wechatpay/ScanPay", typeof(WechatScanPayEndpoint)));
            services.AddSingleton(new Endpoint("wechatWapPay", "/pay-api/Wechatpay/WapPay", typeof(WechatWapPayEndpoint)));
            return services;
        }

        public static IServiceCollection AddWeChatPay(this IServiceCollection services,Action<WeChatPayOptions> action) {
            if (action!=null)
            {
                services.Configure<WeChatPayOptions>(action.Invoke);
            }
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IWeChatPayClient, WeChatPayClient>();
            return services;
        }
    }
}
