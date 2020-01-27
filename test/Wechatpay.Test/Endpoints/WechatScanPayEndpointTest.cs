using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Free.Pay.Wechatpay.Test.Endpoints
{
    public class WechatScanPayEndpointTest
    {
        private HttpContext _context;
        private WechatScanPayEndpoint _subject;

        [Fact]
        public async Task ProcessAsync_WechatScanpay(){
            _context.Request.Method="GET";
            var result=await _subject.ProcessAsync_WechatScanpay(_context);
        }
    }
}