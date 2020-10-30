using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OmniPay.Core.Hosting;
using System;

namespace OmniPay.Unionpay.Extensions
{
    public static class UnionpayServiceCollectionExtensions
    {
        public static IServiceCollection AddUnionPay(this IServiceCollection services, Action<UnionPayOptions> action) 
        {
            //services.AddTransient<IEndpointRouter, EndpointRouter>();
            return services.AddUnionPayServices(action);
        }

        private static IServiceCollection AddUnionPayServices(this IServiceCollection services, Action<UnionPayOptions> action)
        {
            if (action != null)
            {
                services.Configure<UnionPayOptions>(action.Invoke);
            }
            services.AddSingleton<IUnionPayClient, UnionPayClient>();
            return services;
        }
    }
}
