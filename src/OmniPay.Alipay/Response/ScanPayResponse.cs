namespace OmniPay.Alipay.Response
{
    public class ScanPayResponse: BaseResponse
    {
        /// <summary>
        ///     商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        ///     二维码链接
        /// </summary>
        public string QrCode { get; set; }
    }
}
