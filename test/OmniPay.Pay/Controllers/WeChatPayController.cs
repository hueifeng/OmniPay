using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OmniPay.Wechatpay;
using OmniPay.Wechatpay.Domain;
using OmniPay.Wechatpay.Request;

namespace OmniPay.Pay.Controllers
{

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
        /// <summary>
        ///     H5支付
        /// </summary>
        /// <param name="Body"></param>
        /// <param name="Out_Trade_No"></param>
        /// <param name="Total_Amount"></param>
        /// <returns></returns>
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
        /// <summary>
        ///     App支付
        /// </summary>
        /// <param name="Body"></param>
        /// <param name="Out_Trade_No"></param>
        /// <param name="Total_Amount"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<OkObjectResult> AppPay(string Body,string Out_Trade_No,int Total_Amount)
        {
            var request=new AppPayRequest();
            request.AddParameters(new AppPayModel()
            {
                Body = Body,
                OutTradeNo = Out_Trade_No,
                TotalFee = Total_Amount
            });
            return Ok(await _client.ExecuteAsync(request));
        }

        /// <summary>
        ///     公众号支付
        /// </summary>
        /// <param name="Body"></param>
        /// <param name="OutTradeNo"></param>
        /// <param name="TotalAmount"></param>
        /// <param name="OpenId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<OkObjectResult> PublicPay(string Body,string OutTradeNo,int TotalAmount,string OpenId)
        {
            var request=new PublicPayRequest();
            request.AddParameters(new PublicPayModel()
            {
                Body = Body,
                OutTradeNo = OutTradeNo,
                TotalFee = TotalAmount,
                OpenId = OpenId
            });
            return Ok(await  _client.ExecuteAsync(request));
        }

        /// <summary>
        ///     小程序支付
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<OkObjectResult> AppletPay(string Body,string OutTradeNo,int TotalAmount,string OpenId)
        {
            var request=new AppletPayRequest();
            request.AddParameters(new AppletPayModel()
            {
                Body = Body,
                OutTradeNo = OutTradeNo,
                TotalFee = TotalAmount,
                OpenId = OpenId
            });
            return Ok(await _client.ExecuteAsync(request));
        }

        /// <summary>
        ///     查询订单
        /// </summary>
        /// <param name="OuttradeNo"></param>
        /// <param name="TradeNo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<OkObjectResult> Query(string OuttradeNo, string TradeNo)
        {
            var request = new QueryRequest();
            request.AddParameters(new QueryModel()
            {
                 TransactionId = TradeNo,
                 OutTradeNo = OuttradeNo
            });
            return Ok(await _client.ExecuteAsync(request));
        }

        /// <summary>
        ///     关闭订单
        /// </summary>
        /// <param name="OutTradeNo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<OkObjectResult> Close(string OutTradeNo)
        {
            var request = new CloseRequest();
            request.AddParameters(new CloseModel()
            {
                OutTradeNo = OutTradeNo
            });
            return Ok(await _client.ExecuteAsync(request));
        }

    }
}