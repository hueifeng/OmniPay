using Microsoft.AspNetCore.Mvc;
using OmniPay.Alipay;
using OmniPay.Alipay.Domain;
using OmniPay.Alipay.Request;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppPayModel = OmniPay.Alipay.Domain.AppPayModel;
using AppPayRequest = OmniPay.Alipay.Request.AppPayRequest;
using ScanPayModel = OmniPay.Alipay.Domain.ScanPayModel;
using ScanPayRequest = OmniPay.Alipay.Request.ScanPayRequest;

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
            request.AddParameters(new ScanPayModel
            {
                Body = Body,
                OutTradeNo = Out_Trade_No,
                TotalAmount = Total_Amount,
                Subject = "测试扫码支付标题",
                GoodsDetail = new List<Goods>
                {
                    new Goods
                    {
                        Id = "1",
                        Name = "test name",
                        Quantity=1,
                        Price=20
                    }
                }
            });
            return Ok(await _client.ExecuteAsync(request));
        }

        /// <summary>
        ///     app支付
        /// </summary>
        /// <param name="body"></param>
        /// <param name="outTradeNo"></param>
        /// <param name="totalAmount"></param>
        /// <returns></returns>
        public async Task<OkObjectResult> AppPay(string body, string outTradeNo, int totalAmount)
        {
            var request = new AppPayRequest();
            request.AddParameters(new AppPayModel
            {
                Body = body,
                OutTradeNo = outTradeNo,
                TotalAmount = totalAmount,
                Subject = "测试app支付标题"
            });
            return Ok(await _client.ExecuteAsync(request));
        }

        /// <summary>
        ///     手机网站支付
        /// </summary>
        /// <returns></returns>
        public async Task<OkObjectResult> WapPay(string body, string outTradeNo, int totalAmount)
        {
            var request = new WapPayRequest();
            request.AddParameters(new 
            {
                Body = body,
                OutTradeNo = outTradeNo,
                TotalAmount = totalAmount,
                Subject = "测试app支付标题"
            });
            return Ok(await _client.ExecuteAsync(request));
        }

    }
}
