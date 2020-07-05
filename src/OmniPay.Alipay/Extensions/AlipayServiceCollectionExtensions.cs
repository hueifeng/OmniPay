using Microsoft.Extensions.DependencyInjection;
using System;

namespace Free.Pay.Alipay.Extensions
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
