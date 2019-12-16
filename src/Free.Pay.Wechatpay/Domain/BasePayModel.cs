using System;

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
        public string nonce_str { get; set; }
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
        public string Out_trade_no { get; set; }
        /// <summary>
        ///     标价币种
        /// </summary>
        public string Free_Type { get; set; } = "CNY";
        /// <summary>
        ///     标价金额，订单总金额，单位为分
        /// </summary>
        public int Total_free { get; set; }
        /// <summary>
        /// 订单生成时间，格式为yyyyMMddHHmmss
        /// </summary>
        public string TimeStart => DateTime.Now.ToString("yyyyMMddHHmmss");

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

        public string Mch_id { get; set; }

        public string Appid { get; set; }
        /// <summary>
        ///     子商户
        /// </summary>
        public string sub_mch_id { get; set; }

        public string sign { get; set; }

        public string notify_url { get; set; }


    }
}
