namespace OmniPay.Wechatpay.Domain
{
    public class CloseModel
    {
        /// <summary>
        ///     商户订单
        /// 商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。
        /// </summary>
        public string OutTradeNo { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr { get; } = Core.Utils.Extensions.GetNonceStr();
        /// <summary>
        /// 签名类型，默认为MD5，支持HMAC-SHA256和MD5。
        /// </summary>
        public string SignType { get; set; } = "HMAC-SHA256";
    }
}
