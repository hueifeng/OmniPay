namespace OmniPay.Alipay.Domain
{
    /// <summary>
    ///     支付宝支付基类
    /// </summary>
    public class BasePayModel
    {
        /// <summary>
        ///     订单金额,单位为元
        /// </summary>
        public double TotalAmount { get; set; }

        /// <summary>
        ///    对一笔交易的具体描述信息。 
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///    商户网站唯一订单号 
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        ///  	商品的标题/交易标题/订单标题/订单关键字等。
        /// </summary>
        public string Subject { get; set; }

    }
}
