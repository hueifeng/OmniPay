using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OmniPay.Wechatpay.Validation;
using OmniPay.Wechatpay.Validation.Default;
using System;

namespace OmniPay.Wechatpay.Extensions
{
    public static class WeChatServiceCollectionExtensions
    {
        public static IServiceCollection AddWeChatPay(this IServiceCollection services, Action<WeChatPayOptions> action)
        {
            //services.AddSingleton<WechatScanPayEndpoint>();
            //services.AddSingleton<WechatWapPayEndpoint>();
            //services.AddSingleton<WechatAppPayEndpoint>();
            //services.AddSingleton<WechatPublicPayEndpoint>();
            //services.AddSingleton<WechatAppletPayEndpoint>();
            //services.AddSingleton(new Endpoint("wechatScanPay", "/pay-api/Wechatpay/ScanPay", typeof(WechatScanPayEndpoint)));
            //services.AddSingleton(new Endpoint("wechatWapPay", "/pay-api/Wechatpay/WapPay", typeof(WechatWapPayEndpoint)));
            //services.AddSingleton(new Endpoint("wechatAppPay", "/pay-api/Wechatpay/AppPay", typeof(WechatAppPayEndpoint)));
            //services.AddSingleton(new Endpoint("wechatPublicPay", "/pay-api/Wechatpay/PublicPay", typeof(WechatPublicPayEndpoint)));
            //services.AddSingleton(new Endpoint("wechatAppletPay", "/pay-api/Wechatpay/AppletPay", typeof(WechatAppletPayEndpoint)));
            return services.AddWeChatPayServices(action);
        }

        /// <summary>
        ///     验证
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        /// <remarks>
        ///     该验证设计目的主要用于自动api控制层，当然他的当前局限是不可以按照指定模型输出内容
        ///     在后期的模块设计中可以考虑该模块的自定义模型输出
        /// </remarks>
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.TryAddTransient<IScanPayValidator, ScanPayValidator>();
            return services;
        }

        private static IServiceCollection AddWeChatPayServices(this IServiceCollection services, Action<WeChatPayOptions> action)
        {
            if (action != null)
            {
                services.Configure<WeChatPayOptions>(action.Invoke);
            }
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IWeChatPayClient, WeChatPayClient>();
            return services;
        }
    }
}
