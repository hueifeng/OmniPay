using Free.Pay.Core.Hosting;
using Free.Pay.Wechatpay.Endpoints;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WeChatServiceCollectionExtensions
    {
        public static IServiceCollection AddWeChat(this IServiceCollection services) {
            services.AddTransient<IEndpointRouter, EndpointRouter>();
            services.AddSingleton<WechatScanPayEndpoint>();
            services.AddSingleton(new Endpoint("wechatScanPay", "/pay-api/Wechatpay/ScanPay", typeof(WechatScanPayEndpoint)));
            return services;
        }
    }
}
