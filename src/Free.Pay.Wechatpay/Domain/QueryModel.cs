using Free.Pay.Core.Utils;

namespace Free.Pay.Wechatpay.Domain
{
    public class QueryModel
    {
        /// <summary>
        ///     商户系统内部订单号，该订单号和微信订单号二选一即可，如果二者都存在则优先微信订单号
        /// </summary>
        public string OutTradeNo { get; set; }
        /// <summary>
        ///    微信订单号，和商户订单号不能同时为空
        /// </summary>
        public string TransactionId { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; } = Extensions.GetNonceStr();
        /// <summary>
        /// 签名类型，默认为MD5，支持HMAC-SHA256和MD5。
        /// </summary>
        public string SignType { get; set; } = "HMAC-SHA256";
    }
}
