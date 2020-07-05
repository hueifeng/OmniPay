using System;
using Free.Pay.Core.Utils;

namespace Free.Pay.Wechatpay.Domain
{
    /// <summary>
    ///     Pay base class
    /// </summary>
    public class BasePayModel
    {
        /// <summary>
        ///     随机字符串
        /// </summary>
        public string NonceStr { get; set; }= Extensions.GetNonceStr();
        /// <summary>
        ///     设备号
        /// </summary>
        public string DeviceInfo { get; set; }
        /// <summary>
        ///     商品描述
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        ///     商品详细描述
        /// </summary>
        public string Detail { get; set; }
        /// <summary>
        ///     附加数据
        /// </summary>
        public string Attach { get; set; }
        /// <summary>
        ///     商户系统内部订单号
        /// </summary>
        public string OutTradeNo { get; set; }
   
        /// <summary>
        ///     标价金额，订单总金额，单位为分
        /// </summary>
        public int TotalFee { get; set; }

        /// <summary>
        /// 订单生成时间，格式为yyyyMMddHHmmss
        /// </summary>
        public string TimeStart { get; set; }=DateTime.Now.ToString("yyyyMMddHHmmss");

        /// <summary>
        /// 订单失效时间，格式为yyyyMMddHHmmss
        /// 注意：最短失效时间间隔必须大于5分钟
        /// </summary>
        public string TimeExpire { get; set; }

        /// <summary>
        /// 订单优惠标记,使用代金券或立减优惠功能时需要的参数，说明详见代金券或立减优惠
        /// </summary>
        public string GoodsTag { get; set; }

        /// <summary>
        /// 指定支付方式,上传此参数no_credit--可限制用户不能使用信用卡支付
        /// </summary>
        public string LimitPay { get; set; }
        /// <summary>
        /// 签名类型，默认为MD5，支持HMAC-SHA256和MD5。
        /// </summary>
        public string SignType { get; set; } = "HMAC-SHA256";

    }
}
