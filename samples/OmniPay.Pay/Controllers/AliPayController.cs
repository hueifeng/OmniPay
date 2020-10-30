using Aop.Api;
using Aop.Api.Request;
using Aop.Api.Response;
using Microsoft.AspNetCore.Mvc;
using OmniPay.Alipay;
using OmniPay.Alipay.Domain;
using OmniPay.Alipay.Enums;
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

        /// <summary>
        /// PC网站支付
        /// </summary>
        /// <param name="outTradeNo"></param>
        /// <param name="totalAmount"></param>
        /// <returns></returns>
        public async Task<OkObjectResult> WebPagePay(string outTradeNo, decimal totalAmount) 
        {

            //IAopClient client = new DefaultAopClient("https://openapi.alipay.com/gateway.do", "2021000116668110",
            //    "MIIEowIBAAKCAQEA2HLTSTfuFFhRDmb9xc4DVz/e8o/SCXknvPwjQuRIC+MFr+ptj4t3uF4w/j8rqYx2V0ttyGI+MA4byMI/9RYoeX2p9JDcrQHYPIrcmgYIeP5cAl1n1oRhMVjAhtQeI2hYfbelV51SdhGPfIrcUdRNjXMxErrRABeK7vjjdq69ksYdncOOJWZ5O7104Xx98+cOkgJGYABU9V11Gz+/X4P5x90g9iL2pfOmBoMzedfPVLcD4w513emjG3IhHeEdi8vVrmPw7AecF8JPYIpRJBsgM9K+LycwSXW0tMpEjmF28ioisTHvbZpEa+DSEFBIVECry6xXw/utzv7IYLmNwQM3qwIDAQABAoIBAQCWu0gGOivTATnZRMG/KVtMPE9/LcbAEB4rTo8juyOtG3jPa/rGNwK1YurNc6JtXULgQcf+/uN9xaV1pkix3a9sA6YCiYsT9C/o4W8E1+S4lbHvd6qjSecBXWQdwMQINldBnU1IeWd+j3YT7gPF/InRUoG/IFgBr2NyTeLhuIiOF56wEqLa3m1KChGjpMMkJWObBTQqoAAiWe327XxYETRz38x1qc8sfGGleyCo2QqRS6o7A7BdsrkSgMq7HAoo9gZsQBOIEKEsi0gdFq47/ybHDw43TXhMeL0PM7ezKJ4ky/bg/N9PVGP3mKlD2snXk+lUZikkmNH56mVNSAq3Wi3hAoGBAP2FF3+RODmPoNqtcfk6luMaMerZOdcgnmsys0ry/ji1VYeTysfvXwWXT6kcoWG6OFPvPKUgTtAvy2X4GV7KCnmpkM2YL309ha6HYc3dAJHrYObwLG6mPIVoOQsgxYqrNeDAL0PmcMfy9F/ergRjcQfxwwajpDIF+sAMVIfujCW7AoGBANqQ5KBjXKRPhg1eP5PTD+xIhJNffMD7nL9m1R71XjNWdMXOhdCFb1di1CBmb5V9KEHZudKSnAaL8n5jjOtoCNX3vcBOjcY7LcEpOFWrvKWu/PQ3OUSaNvjEM82TDffhXsdhPz+FXmhf4WWKytmU9KIsHK16akKSjbc17z1vfZ7RAoGAZ1LU7uLqvVryPe2uo9rjIA/PBF4gGrNqnVn+hK9gORB+mVD8tluyqH6wssW+aCwTRPIeD1aJiIPSK+7fuCgz+L3JDGHYCP0H/MekbtiBoPcDeVutYDNUOzLs/MIQgKGixcTN/qhukq9MNb51wcgdixVXXN9YziJtvdPIp9XrPH0CgYADfQiJHszdun8zO2vcWiQI62diSsXc9qcbzvJb2iK0ww5+EbvFBjwust8b3Uauph68XlM+7yQaXqVyKviW0URC1f9rUFWm8k7apGPHykPqiQ50f2UkmSmDcu44u74fVLOEjyLJSsGk/NLGIh72tg/pfra+dhO4GEq2v9+fpWXl4QKBgE4UzbW/VBN7mFF2sDuN7W9WGl0r0ikCP+2UBMCBsNPORQlHRkFbTB0wdKwbCmvrG3iRmk947KzdZKJSmkMlLjTCrKddAwog/yPzEvzIV5eUctARXyox7WTihEo/JIqwmbzTiAcXqVYhzDKUMP4k42J/Ugc0JMZXu0hXwPsV77kn", 
            //    "json", "1.0", "RSA2", 
            //    "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAmx3bj8uy6tN1LtrouRoe0BMCRVtfgKQDRN9mYbueSnd0M5//SiJuvkRkxVfuUIylb/5xTjPGT5VdPKDiyfv3d+9UsqcQnotp/oQm3UF8SLBishvXH02ufvg2qxXiMp2sORYLCSpp0Ycq5gcyOwJdv/4nBGDhD6FWmtbqbSPmu2NZDpKpGS1IoM3PF1heZIoXx7LtBL9MKh6g1TStwRCo/QXrZAn5A4o9/TojwDob3yfdC3acnnJcfEsjGAsJ5Ivxj2Ls20LWI+DHnQVMrByDXnH5qrRyAg6LBvcidAAusUwbQZdsoJkGLu7whh3xMixLCr1Qhjr9hILcskuUoqxK4QIDAQAB",
            //    "UTF-8", false);
            //AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
            //request.BizContent = "{" +
            //"\"out_trade_no\":\"20150320010101001\"," +
            //"\"product_code\":\"FAST_INSTANT_TRADE_PAY\"," +
            //"\"total_amount\":88.88," +
            //"\"subject\":\"Iphone6 16G\"," +
            ////"\"body\":\"Iphone6 16G\"," +
            ////"\"time_expire\":\"2016-12-31 10:05:01\"," +
            ////"      \"goods_detail\":[{" +
            ////"        \"goods_id\":\"apple-01\"," +
            ////"\"alipay_goods_id\":\"20010001\"," +
            ////"\"goods_name\":\"ipad\"," +
            ////"\"quantity\":1," +
            ////"\"price\":2000," +
            ////"\"goods_category\":\"34543238\"," +
            ////"\"categories_tree\":\"124868003|126232002|126252004\"," +
            ////"\"body\":\"特价手机\"," +
            ////"\"show_url\":\"http://www.alipay.com/xxx.jpg\"" +
            ////"        }]," +
            ////"\"passback_params\":\"merchantBizType%3d3C%26merchantBizNo%3d2016010101111\"," +
            ////"\"extend_params\":{" +
            ////"\"sys_service_provider_id\":\"2088511833207846\"," +
            ////"\"hb_fq_num\":\"3\"," +
            ////"\"hb_fq_seller_percent\":\"100\"," +
            ////"\"industry_reflux_info\":\"{\\\\\\\"scene_code\\\\\\\":\\\\\\\"metro_tradeorder\\\\\\\",\\\\\\\"channel\\\\\\\":\\\\\\\"xxxx\\\\\\\",\\\\\\\"scene_data\\\\\\\":{\\\\\\\"asset_name\\\\\\\":\\\\\\\"ALIPAY\\\\\\\"}}\"," +
            ////"\"card_type\":\"S0JP0000\"" +
            ////"    }," +
            ////"\"goods_type\":\"0\"," +
            ////"\"timeout_express\":\"90m\"," +
            ////"\"promo_params\":\"{\\\"storeIdType\\\":\\\"1\\\"}\"," +
            ////"\"royalty_info\":{" +
            ////"\"royalty_type\":\"ROYALTY\"," +
            ////"        \"royalty_detail_infos\":[{" +
            ////"          \"serial_no\":1," +
            ////"\"trans_in_type\":\"userId\"," +
            ////"\"batch_no\":\"123\"," +
            ////"\"out_relation_id\":\"20131124001\"," +
            ////"\"trans_out_type\":\"userId\"," +
            ////"\"trans_out\":\"2088101126765726\"," +
            ////"\"trans_in\":\"2088101126708402\"," +
            ////"\"amount\":0.1," +
            ////"\"desc\":\"分账测试1\"," +
            ////"\"amount_percentage\":\"100\"" +
            ////"          }]" +
            ////"    }," +
            ////"\"sub_merchant\":{" +
            ////"\"merchant_id\":\"2088000603999128\"," +
            ////"\"merchant_type\":\"alipay: 支付宝分配的间连商户编号, merchant: 商户端的间连商户编号\"" +
            ////"    }," +
            ////"\"merchant_order_no\":\"20161008001\"," +
            ////"\"enable_pay_channels\":\"pcredit,moneyFund,debitCardExpress\"," +
            ////"\"store_id\":\"NJ_001\"," +
            ////"\"disable_pay_channels\":\"pcredit,moneyFund,debitCardExpress\"," +
            ////"\"qr_pay_mode\":\"1\"," +
            ////"\"qrcode_width\":100," +
            ////"\"settle_info\":{" +
            ////"        \"settle_detail_infos\":[{" +
            ////"          \"trans_in_type\":\"cardAliasNo\"," +
            ////"\"trans_in\":\"A0001\"," +
            ////"\"summary_dimension\":\"A0001\"," +
            ////"\"settle_entity_id\":\"2088xxxxx;ST_0001\"," +
            ////"\"settle_entity_type\":\"SecondMerchant、Store\"," +
            ////"\"amount\":0.1" +
            ////"          }]," +
            ////"\"settle_period_time\":\"7d\"" +
            ////"    }," +
            ////"\"invoice_info\":{" +
            ////"\"key_info\":{" +
            ////"\"is_support_invoice\":true," +
            ////"\"invoice_merchant_name\":\"ABC|003\"," +
            ////"\"tax_num\":\"1464888883494\"" +
            ////"      }," +
            ////"\"details\":\"[{\\\"code\\\":\\\"100294400\\\",\\\"name\\\":\\\"服饰\\\",\\\"num\\\":\\\"2\\\",\\\"sumPrice\\\":\\\"200.00\\\",\\\"taxRate\\\":\\\"6%\\\"}]\"" +
            ////"    }," +
            ////"\"agreement_sign_params\":{" +
            ////"\"personal_product_code\":\"GENERAL_WITHHOLDING_P\"," +
            ////"\"sign_scene\":\"INDUSTRY|CARRENTAL\"," +
            ////"\"external_agreement_no\":\"test\"," +
            ////"\"external_logon_id\":\"13852852877\"," +
            ////"\"sign_validity_period\":\"2m\"," +
            ////"\"third_party_type\":\"PARTNER\"," +
            ////"\"buckle_app_id\":\"1001164\"," +
            ////"\"buckle_merchant_id\":\"268820000000414397785\"," +
            ////"\"promo_params\":\"{\\\"key\\\",\\\"value\\\"}\"" +
            ////"    }," +
            ////"\"integration_type\":\"PCWEB\"," +
            ////"\"request_from_url\":\"https://\"," +
            ////"\"business_params\":\"{\\\"data\\\":\\\"123\\\"}\"," +
            ////"\"ext_user_info\":{" +
            ////"\"name\":\"李明\"," +
            ////"\"mobile\":\"16587658765\"," +
            ////"\"cert_type\":\"IDENTITY_CARD\"," +
            ////"\"cert_no\":\"362334768769238881\"," +
            ////"\"min_age\":\"18\"," +
            ////"\"fix_buyer\":\"F\"," +
            ////"\"need_check_info\":\"F\"" +
            ////"    }" +
            //"  }";
            //AlipayTradePagePayResponse response = client.pageExecute(request);
            //return Ok(response.Body);


            //此处接口报错 经测试为Alipay测试网关问题 更换为正式网关则可解决
            var request1 = new WebPagePayRequest();
            request1.AddParameters(new
            {
                OutTradeNo = outTradeNo,
                ProductCode = "FAST_INSTANT_TRADE_PAY",
                TotalAmount = totalAmount,
                Subject = "测试PC支付标题",

            });
            return Ok(await _client.ExecuteAsync(request1));
        }



        /// <summary>
        /// 条码支付
        /// </summary>
        /// <param name="outTradeNo"></param>
        /// <param name="authCode"></param>
        /// <param name="totalAmount"></param>
        /// <returns></returns>
        public async Task<OkObjectResult> BarCodePay(string outTradeNo, string authCode, decimal totalAmount) 
        {
            var request = new BarCodePayRequest();
            request.AddParameters(new
            {
                OutTradeNo = outTradeNo,
                Scene = "bar_code",
                AuthCode = authCode,
                TotalAmount = totalAmount,
                Subject = "测试条码支付"
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
        /// 注意：这个接口是下载离线账单的，需要T+1天生成账单，不能查询当日或者是当月的账单，如果日期是当天或者是
        /// 当月的会返回“参数不合法”
        /// </summary>
        /// <param name="billDate"></param>
        /// <returns></returns>
        public async Task<OkObjectResult> BillDownload(string billDate) 
        {
            var request = new BillDownloadRequest();
            request.AddParameters(new
            {
                BillType = BillType.SignCustomer.ToString().ToLower(),
                BillDate = billDate,
            });
            return Ok(await _client.ExecuteAsync(request));
        }

    }
}
