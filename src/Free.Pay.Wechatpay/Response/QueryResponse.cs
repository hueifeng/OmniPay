namespace Free.Pay.Wechatpay.Response
{
    public class QueryResponse:BaseResponse
    {
        /// <summary>
        ///     用户标识
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        ///     是否关注公众账号
        /// 用户是否关注公众账号,Y-关注，N-未关注
        /// </summary>
        public string IsSubscribe { get; set; }
        /// <summary>
        ///     交易类型
        /// 调用接口提交的交易类型,取值如下：JSAPI,NATIVE,APP,MICROPAY
        /// </summary>
        public string TradeType { get; set; }
        /// <summary>
        ///     交易状态
        /// SUCCESS-支付成功
        /// REFUND-转入退款
        /// NOTPAY-未支付
        /// CLOSED-已关闭
        /// REVOKED-已撤销（刷卡支付）
        /// USERPAYING-用户支付中
        /// PAYERROR-支付失败（其他原因,如银行返回失败）
        /// 支付状态机请见下单API页面
        /// </summary>
        public string TradeState { get; set; }
        /// <summary>
        ///     银行类型，采用字符串类型的银行标识，详见银行类型
        /// </summary>
        public string BankType { get; set; }
        /// <summary>
        ///     订单金额
        /// 订单总金额，单位为分
        /// </summary>
        public int TotalFree { get; set; }
        /// <summary>
        ///     现金支付货币类型
        /// 货币类型，符合ISO 4217标准的三位字符代码，默认人民币：CNY，其他值列表详见
        /// </summary>
        public string CashFreeType { get; set; }
        /// <summary>
        ///     代金券金额
        /// "代金券"金额≤订单金额,订单金额-"代金券"金额=现金支付金额
        /// </summary>
        public int CouponFree { get; set; }
        /// <summary>
        ///     代金券使用数量
        /// </summary>
        public string CouponCount { get; set; }
        /// <summary>
        ///     微信支付订单号
        /// </summary>
        public string TransactionId { get; set; }
        /// <summary>
        ///     商户订单号
        /// </summary>
        public string OutTradeNo { get; set; }
        /// <summary>
        ///     商户附加数据包
        /// </summary>
        public string Attach { get; set; }
        /// <summary>
        ///     支付完成时间
        /// </summary>
        public string TimeEnd { get; set; }
        /// <summary>
        ///     交易状态描述
        /// </summary>
        public string TradeStateDesc { get; set; }
    }
}
