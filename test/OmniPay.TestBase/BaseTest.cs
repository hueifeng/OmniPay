using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using OmniPay.Core.Utils;
using OmniPay.Wechatpay;

namespace OmniPay.TestBase
{
    public class BaseTest
    {
        public IServiceCollection CreateServiceCollection()
        {
            return new ServiceCollection();
        }

        public IServiceCollection Services { get; set; }

        public IServiceProvider ServiceProvider { get; set; }

        public T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        public T GetRequiredService<T>()
        {
            return ServiceProvider.GetRequiredService<T>();
        }

    }
}
