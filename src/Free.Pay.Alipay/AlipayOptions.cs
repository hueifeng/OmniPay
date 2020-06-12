using System;

namespace Free.Pay.Alipay
{
    public class AlipayOptions
    {
        
        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 签名类型
        /// </summary>
        public string SignType { get; set; } = "RSA2";

        /// <summary>
        /// 格式
        /// </summary>
        public string Format => "JSON";

        /// <summary>
        /// 时间戳
        /// </summary>
        public string Timestamp => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 版本
        /// </summary>
        public string Version => "1.0";

        /// <summary>
        /// 编码格式
        /// </summary>
        public string Charset => "UTF-8";

        /// <summary>
        /// 商户私钥
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>
        /// 支付宝公钥
        /// </summary>
        public string AlipayPublicKey { get; set; }

        /// <summary>
        /// 返回地址
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// 网关回发通知URL
        /// </summary>
        public string NotifyUrl { get; set; }
    }
}