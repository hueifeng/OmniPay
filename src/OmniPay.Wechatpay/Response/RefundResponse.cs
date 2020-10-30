namespace OmniPay.Wechatpay.Response
{
    public class RefundResponse : BaseResponse
    {
        /// <summary>
        ///     微信订单号
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        ///     商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        ///     商户退款单号
        /// </summary>
        public string OutRefundNo { get; set; }

        /// <summary>
        ///     微信退款单号
        /// </summary>
        public string RefundId { get; set; }

        /// <summary>
        ///     退款金额
        /// </summary>
        public int RefundFee { get; set; }

        /// <summary>
        ///     应结退款金额
        /// </summary>
        public int SettlementRefundFee { get; set; }

        /// <summary>
        ///     标价金额
        /// </summary>
        public int TotalFee { get; set; }

        /// <summary>
        ///     现金支付金额
        /// </summary>
        public int CashFee { get; set; }

        /// <summary>
        ///     现金支付币种
        /// </summary>
        public string CashFeeType { get; set; }

        /// <summary>
        ///     代金券退款总金额
        /// </summary>
        public int CouponRefundFee { get; set; }

        /// <summary>
        ///     退款代金券使用数量
        /// </summary>
        public int CouponRefundCount { get; set; }
    }
}
