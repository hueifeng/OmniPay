using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OmniPay.Alipay;
using OmniPay.Alipay.Domain;
using OmniPay.Alipay.Enums;
using OmniPay.Alipay.Request;
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

        /// <summary>
        /// 交易查询
        /// </summary>
        /// <param name="outTradeNo"></param>
        /// <param name="tradeNo"></param>
        /// <returns></returns>
        public async Task<OkObjectResult> TradeQuery(string outTradeNo, string tradeNo) 
        {
            var request = new TradeQueryRequest();
            request.AddParameters(new
            {
                TradeNo = tradeNo,
                OutTradeNo = outTradeNo,
            });
            return Ok(await _client.ExecuteAsync(request));
        }

        /// <summary>
        /// 交易退款
        /// </summary>
        /// <param name="outTradeNo"></param>
        /// <param name="tradeNo"></param>
        /// <param name="totalAmount"></param>
        /// <returns></returns>
        public async Task<OkObjectResult> TradeRefund(string outTradeNo, string tradeNo, decimal refundAmount) 
        {
            var request = new TradeRefundRequest();
            request.AddParameters(new
            {
                TradeNo = tradeNo,
                OutTradeNo = outTradeNo,
                RefundAmount = refundAmount,
            });
            return Ok(await _client.ExecuteAsync(request));
        }

        /// <summary>
        /// 退款查询
        /// </summary>
        /// <returns></returns>
        public async Task<OkObjectResult> RefundQuery(string outTradeNo, string tradeNo, string outRequestNo) 
        {
            var request = new RefundQueryRequest();
            request.AddParameters(new
            {
                TradeNo = tradeNo,
                OutTradeNo = outTradeNo,
                OutRequestNo = outRequestNo
            });
            return Ok(await _client.ExecuteAsync(request));
        }

        /// <summary>
        /// 交易撤销
        /// </summary>
        /// <param name="outTradeNo"></param>
        /// <param name="tradeNo"></param>
        /// <returns></returns>
        public async Task<OkObjectResult> TradeCancel(string outTradeNo, string tradeNo) 
        {
            var request = new TradeCancelRequest();
            request.AddParameters(new
            {
                TradeNo = tradeNo,
                OutTradeNo = outTradeNo,
            });
            return Ok(await _client.ExecuteAsync(request));
        }

        /// <summary>
        /// 交易关闭
        /// </summary>
        /// <param name="outTradeNo"></param>
        /// <param name="tradeNo"></param>
        /// <returns></returns>
        public async Task<OkObjectResult> TradeClose(string outTradeNo, string tradeNo)
        {
            var request = new TradeCloseRequest();
            request.AddParameters(new
            {
                TradeNo = tradeNo,
                OutTradeNo = outTradeNo,
            });
            return Ok(await _client.ExecuteAsync(request));
        }

        /// <summary>
        /// 单笔转账
        /// </summary>
        /// <param name="outBizNo"></param>
        /// <param name="transAmount"></param>
        /// <param name="identity"></param>
        /// <param name="identityType"></param>
        /// <returns></returns>
        public async Task<OkObjectResult> Transfer(string outBizNo, decimal transAmount, string identity)
        {
            var request = new TransferRequest();
            request.AddParameters(new
            {
                OutBizNo = outBizNo,
                TransAmount = transAmount,
                ProductCode = TransProductCode.TRANS_ACCOUNT_NO_PWD.ToString(),
                BizScene = TransBizScene.DIRECT_TRANSFER.ToString(),
                PayeeInfo = new  
                {
                    identity = identity,
                    name = "张敬文",
                    identity_type = TransIdentityType.ALIPAY_LOGON_ID.ToString()
                }

            });
            return Ok(await _client.ExecuteAsync(request));
        }

        /// <summary>
        /// 转账订单查询
        /// </summary>
        /// <param name="outBizNo"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<OkObjectResult> TransferQuery(string outBizNo, string orderId) 
        {
            var request = new TransferQueryRequest();
            request.AddParameters(new
            {
                OutBizNo = outBizNo,
                OrderId = orderId,                
            });
            return Ok(await _client.ExecuteAsync(request));
        }

        /// <summary>
        /// 下载对账单
        /// </summary>
        /// <param name="billDate"></param>
        /// <returns></returns>
        public async Task<OkObjectResult> BillDownload(string billDate) 
        {
            var request = new BillDownloadRequest();
            request.AddParameters(new
            {
                BillType = BillType.Trade.ToString().ToLower(),
                BillDate = billDate,
            });
            return Ok(await _client.ExecuteAsync(request));
        }
    }
}
