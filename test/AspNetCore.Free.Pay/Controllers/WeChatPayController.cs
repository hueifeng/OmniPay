using Free.Pay.Wechatpay;
using Free.Pay.Wechatpay.Domain;
using Free.Pay.Wechatpay.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCore.Free.Pay.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WeChatPayController : ControllerBase
    {
        private readonly IWeChatPayClient _client;

        public WeChatPayController(IWeChatPayClient client)
        {
            _client = client;
        }
        /// <summary>
        ///     扫码支付
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<OkObjectResult> ScanPay(string Body,string Out_Trade_No,int Total_Amount)
        {
            var request = new ScanPayRequest();
            request.AddParameters(new ScanPayModel()
            {
                Body = Body,
                OutTradeNo = Out_Trade_No,
                TotalFee = Total_Amount
            });
            return Ok(await _client.ExecuteAsync(request));
        }

        [HttpPost]
        public async Task<OkObjectResult> WapPay(string Body, string Out_Trade_No, int Total_Amount)
        {
            var request = new WapPayRequest();
            request.AddParameters(new WapPayModel()
            {
                Body = Body,
                OutTradeNo = Out_Trade_No,
                TotalFee = Total_Amount
            });
            return Ok(await _client.ExecuteAsync(request));
        }




    }
}