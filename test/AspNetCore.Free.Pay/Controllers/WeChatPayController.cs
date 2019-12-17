using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Free.Pay.Wechatpay;
using Free.Pay.Wechatpay.Domain;
using Free.Pay.Wechatpay.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AspNetCore.Free.Pay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeChatPayController : ControllerBase
    {
        private readonly IWeChatPayClient _client;

        private readonly WeChatPayOptions _weChatPayOptions;
        public WeChatPayController(IWeChatPayClient client, IOptionsMonitor<WeChatPayOptions> weChatPayOptions)
        {
            _client = client;
            _weChatPayOptions = weChatPayOptions.CurrentValue;
        }

        [HttpPost]
        public async Task<OkObjectResult> ScanPay()
        {
            var request = new ScanPayRequest();
            request.AddParameters(new ScanPayModel()
            {
                spbill_create_ip = "124.128.251.218",
                nonce_str = "5K8264ILTKCH16CQ2502SI8ZNMTM67VS",
                sign_type = "HMAC-SHA256",
                time_start = DateTime.Now.ToString("yyyyMMddHHmmss"),
                Body = "hahaha",
                Attach = "ghasg11",
                Out_trade_no = "20150806125346",
                total_fee = 10,
                time_expire = DateTime.Now.AddDays(2).ToString("yyyyMMddHHmmss"),
                product_id = "12235413214058",
                notify_url = "http://www.weixin.qq.com/wxpay/pay.php",
                trade_type = "NATIVE",
                goods_tag = "111"
            });
            return Ok(await _client.ExecuteAsync(request));
        }

    }
}