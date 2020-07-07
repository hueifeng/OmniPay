using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OmniPay.Core.Results;
using OmniPay.Wechatpay;
using OmniPay.Wechatpay.Endpoints;
using OmniPay.Wechatpay.Endpoints.Result;
using Xunit;

namespace Wechatpay.Test.Endpoints
{
    public class WechatWapPayEndpointTest
    {
        HttpContext _context = new DefaultHttpContext ();
        private ILogger<WeChatPayClient> wechatpaylogger = new LoggerFactory ().CreateLogger<WeChatPayClient> ();
        private ILogger<WechatWapPayEndpoint> logger = new LoggerFactory ().CreateLogger<WechatWapPayEndpoint> ();
        IWeChatPayClient _client;
        private WechatWapPayEndpoint _subject;

        private void init () {
            var someOptions = Options.Create (new WeChatPayOptions {
                AppId = "wxdace645e0bc2c424",
                    AppSecret = "4693afc6b2084885ca9fbc2355b97827",
                    BaseUrl = "https://api.mch.weixin.qq.com",
                    Key = "1900009641"
            });
            _client = new WeChatPayClient (someOptions, wechatpaylogger);
            _subject = new WechatWapPayEndpoint (logger, _client);
        }
        public WechatWapPayEndpointTest () {
            this.init ();
        }

        [Fact]
        public void Process_get_entry_point_shoud_return_405 () {
            _context.Request.Method = "GET";
            var result = _subject.Process (_context);
            var statusCode = result as StatusCodeResult;
            statusCode.Should ().NotBeNull ();
            statusCode.StatusCode.Should ().Be (405);
        }

        [Fact]
        public void Process_apppay_path_should_return_wappay_result () {
            _context.Request.Method = "POST";
            var result = _subject.Process (_context);
            result.Should ().BeOfType<WapPayResult> ();
        }
    }
}