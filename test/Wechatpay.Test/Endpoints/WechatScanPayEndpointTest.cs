using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Free.Pay.Wechatpay.Endpoints;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FluentAssertions;
using Free.Pay.Core.Results;

namespace Free.Pay.Wechatpay.Test.Endpoints
{
    public class WechatScanPayEndpointTest
    {
        HttpContext _context= new DefaultHttpContext();
        private ILogger<WeChatPayClient> wechatpaylogger = new LoggerFactory().CreateLogger<WeChatPayClient>();     
        private ILogger<WechatScanPayEndpoint> logger = new LoggerFactory().CreateLogger<WechatScanPayEndpoint>();

         IWeChatPayClient _client;
         private WechatScanPayEndpoint _subject;

        private void init(){
            var someOptions = Options.Create(new WeChatPayOptions{
                AppId="wxdace645e0bc2c424",
                AppSecret="4693afc6b2084885ca9fbc2355b97827",
                BaseUrl="https://api.mch.weixin.qq.com",
                Key="1900009641"
            });
            _client=new WeChatPayClient(someOptions,wechatpaylogger);
            _subject=new WechatScanPayEndpoint(logger,_client);
        }

        [Fact]
        public void Process_get_entry_point_shoud_return_405(){
            init();
            _context.Request.Method="GET";
            var result=_subject.Process(_context);
            var statusCode = result as StatusCodeResult;
            statusCode.Should().NotBeNull();
            statusCode.StatusCode.Should().Be(405);
        }
    }
}