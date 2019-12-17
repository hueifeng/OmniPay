namespace Free.Pay.Wechatpay.Response
{
    public class ScanPayResponse:BaseResponse
    {
        /// <summary>
        /// 交易类型
        /// </summary>
        public string trade_type { get; set; }

        /// <summary>
        /// 微信生成的预支付回话标识，用于后续接口调用中使用，该值有效期为2小时
        /// </summary>
        public string prepay_id { get; set; }

        /// <summary>
        /// 二维码链接
        /// </summary>
        public string code_url { get; set; }
    }
}
