using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using OmniPay.Core.Utils;
using OmniPay.Wechatpay;
using OmniPay.Wechatpay.Domain;
using OmniPay.Wechatpay.Request;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Wechatpay.Test.Core;
using Xunit;

namespace Wechatpay.Test.WeChatPays
{
    public class WeChatPayTest : WechatBaseTest
    {
        private readonly IWeChatPayClient _client;

        public WeChatPayTest()
        {
            _client = GetRequiredService<IWeChatPayClient>();
        }

        [Fact(DisplayName = "微信扫码支付是否返回成功")]
        public async Task ScanPay_shoud_return_success()
        {
            var request = new ScanPayRequest();
            request.AddParameters(new ScanPayModel
            {
                Body = "扫码支付",
                OutTradeNo = DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                TotalFee = 1
            });
            var result = await _client.ExecuteAsync(request);
            result.ResultCode.Should().Be("SUCCESS", "判断其是否返回SUCCESS");

        }
    }
}
