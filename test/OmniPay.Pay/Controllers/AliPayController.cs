using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OmniPay.Alipay;
using OmniPay.Alipay.Domain;
using OmniPay.Alipay.Request;

namespace OmniPay.Pay.Controllers
{
    public class AliPayController : ControllerBase
    {
        private readonly IAliPayClient _client;
        public AliPayController(IAliPayClient client)
        {
            this._client = client;
        }

        /// <summary>
        ///     扫码支付
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<OkObjectResult> ScanPay(string Body, string Out_Trade_No, int Total_Amount)
        {
            var request = new ScanPayRequest();
            request.AddParameters(new ScanPayModel()
            {
                Body = Body,
                OutTradeNo = Out_Trade_No,
                TotalAmount = Total_Amount
            });
            return Ok(await _client.ExecuteAsync(request));
        }
    }
}
