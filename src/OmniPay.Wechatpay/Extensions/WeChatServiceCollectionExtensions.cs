using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OmniPay.Core.Hosting;
using OmniPay.Wechatpay.Endpoints;
using Endpoint = OmniPay.Core.Hosting.Endpoint;

namespace OmniPay.Wechatpay.Extensions
{
    public static class WeChatServiceCollectionExtensions
    {
        public static IServiceCollection AddWeChatPay(this IServiceCollection services,Action<WeChatPayOptions> action) {
            services.AddTransient<IEndpointRouter, EndpointRouter>();
            services.AddSingleton<WechatScanPayEndpoint>();
            services.AddSingleton<WechatWapPayEndpoint>();
            services.AddSingleton<WechatAppPayEndpoint>();
            services.AddSingleton<WechatPublicPayEndpoint>();
            services.AddSingleton<WechatAppletPayEndpoint>();
            services.AddSingleton(new Endpoint("wechatScanPay", "/pay-api/Wechatpay/ScanPay", typeof(WechatScanPayEndpoint)));
            services.AddSingleton(new Endpoint("wechatWapPay", "/pay-api/Wechatpay/WapPay", typeof(WechatWapPayEndpoint)));
            services.AddSingleton(new Endpoint("wechatAppPay", "/pay-api/Wechatpay/AppPay", typeof(WechatAppPayEndpoint)));
            services.AddSingleton(new Endpoint("wechatPublicPay", "/pay-api/Wechatpay/PublicPay", typeof(WechatPublicPayEndpoint)));
            services.AddSingleton(new Endpoint("wechatAppletPay", "/pay-api/Wechatpay/AppletPay", typeof(WechatAppletPayEndpoint)));
            return services.AddWeChatPayServices(action);
        }

        private static IServiceCollection AddWeChatPayServices(this IServiceCollection services,Action<WeChatPayOptions> action) {
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
