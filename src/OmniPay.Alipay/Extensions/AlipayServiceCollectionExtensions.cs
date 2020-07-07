using System;
using Microsoft.Extensions.DependencyInjection;

namespace OmniPay.Alipay.Extensions
{
    public static class AlipayServiceCollectionExtensions
    {
        public static IServiceCollection AddAliPay(this IServiceCollection services, Action<AlipayOptions> action)
        {
            return services.AddAliServices(action);
        }

        private static IServiceCollection AddAliServices(this IServiceCollection services, Action<AlipayOptions> action)
        {
            if (action != null)
            {
                services.Configure<AlipayOptions>(action.Invoke);
            }
            return services;
        }
    }
}
