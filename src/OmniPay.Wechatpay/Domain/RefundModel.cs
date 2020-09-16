namespace OmniPay.Wechatpay.Domain
{
    public class RefundModel
    {
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; } = Core.Utils.Extensions.GetNonceStr();
        /// <summary>
        /// 签名类型，默认为MD5，支持HMAC-SHA256和MD5。
        /// </summary>
        public string SignType { get; set; } = "HMAC-SHA256";

        /// <summary>
        ///     微信订单号
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        ///     商户订单
        /// 商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        ///     商户退款单号
        /// </summary>
        public string OutRefundNo { get; set; }

        /// <summary>
        ///     订单金额
        /// </summary>
        public int TotalFee { get; set; }

        /// <summary>
        ///     退款金额
        /// </summary>
        public int RefundFee { get; set; }

        /// <summary>
        ///     退款货币种类
        /// </summary>
        public string RefundFeeType { get; set; }

        /// <summary>
        ///     退款原因
        /// </summary>
        public string RefundDesc { get; set; }

        /// <summary>
        ///     退款资金来源
        /// </summary>
        public string RefundAccount { get; set; }
    }
}
