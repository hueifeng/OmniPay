using Newtonsoft.Json;

namespace OmniPay.Alipay.Response
{
    public class ScanPayResponse : BaseResponse
    {
        /// <summary>
        ///     商户订单号
        /// </summary>
        [JsonProperty("out_trade_no")]
        public string OutTradeNo { get; set; }

        /// <summary>
        ///     二维码链接
        /// </summary>
        [JsonProperty("qr_code")]
        public string QrCode { get; set; }
    }
}
