using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using OmniPay.Core.Utils;
using OmniPay.TestBase;
using OmniPay.Wechatpay;
using System.Net.Http;

namespace Wechatpay.Test.Core
{
    public class WechatBaseTest : BaseTest
    {
        public WechatBaseTest()
        {
            //添加ILogger
            ILogger<WeChatPayClient> wechatpaylogger =
                new LoggerFactory().CreateLogger<WeChatPayClient>();
            //添加配置参数
            var someOptions = Options.Create(new WeChatPayOptions
            {
                AppId = "wxdace645e0bc2c424",
                AppSecret = "4693afc6b2084885ca9fbc2355b97827",
                Key = "b7c996fbda5a9633ee4feb6b991c3919",
                BaseUrl = "https://api.mch.weixin.qq.com",
                MchId = "1900009641",
                NotifyUrl = "http://localhost:6113"
            });
            //mock IHttpClientFactory
            var mock = new Mock<IHttpClientFactory>();
            mock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(new HttpClient());
            IHttpClientFactory factory = mock.Object;
            var client = new WeChatPayClient(someOptions, wechatpaylogger, new HttpHandler(factory));

            Services = CreateServiceCollection();
            Services.AddSingleton<IWeChatPayClient>(client);
            ServiceProvider = Services.BuildServiceProvider();

        }

    }
}
