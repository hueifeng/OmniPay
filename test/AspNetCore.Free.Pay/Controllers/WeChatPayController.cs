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

        public WeChatPayController(IWeChatPayClient client)
        {
            _client = client;
        }

        [HttpPost]
        public async Task<OkObjectResult> ScanPay()
        {
            var request = new ScanPayRequest();
            request.AddParameters(new ScanPayModel()
            {
                Body = "hahaha",
                Out_trade_no = "20150806125346",
                total_fee = 10
            });
            return Ok(await _client.ExecuteAsync(request));
        }

    }
}