using System;
using System.Collections.Generic;
using System.Text;

namespace OmniPay.Unionpay
{
    public class UnionPayOptions
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 编码方式
        /// </summary>
        public string Encoding => "UTF-8";

        /// <summary>
        /// 产品类型
        /// </summary>
        public string BizType => "000201";

        /// <summary>
        /// 订单发送时间
        /// </summary>
        public string TxnTime => DateTime.Now.ToString("yyyyMMddHHmmss");

        /// <summary>
        /// 后台通知地址
        /// </summary>
        public string BackUrl;

        /// <summary>
        /// 交易币种
        /// </summary>
        public string CurrencyCode => "156";

        /// <summary>
        /// 交易类型
        /// </summary>
        public string TxnType => "01";

        /// <summary>
        /// 交易子类
        /// </summary>
        public string TxnSubType => "01";

        /// <summary>
        /// 接入类型
        /// </summary>
        public string AccessType => "0";

        /// <summary>
        /// 签名
        /// </summary>
        public string Signature;

        /// <summary>
        /// 签名方法
        /// </summary>
        public string SignMethod { get; set; }

        /// <summary>
        /// 渠道类型
        /// </summary>
        public string ChannelType => "08";

        /// <summary>
        /// 商户代码
        /// </summary>
        public string MerId { get; set; }

        public string BaseUrl { get; set; }

        /// <summary>
        /// 前台通知地址
        /// </summary>
        public string FrontUrl { get; set; }

        /// <summary>
        /// 签名证书路径
        /// </summary>
        public string SignCertPath { get; set; }

        /// <summary>
        /// 签名证书密码
        /// </summary>
        public string SignCertPwd { get; set; }

        /// <summary>
        /// 加密证书 
        /// </summary>
        public string EncryptCertPath { get; set; }

        /// <summary>
        /// 验签中级证书
        /// </summary>
        public string MiddleCertPath { get; set; }

        /// <summary>
        /// 验签根证书 
        /// </summary>
        public string RootCertPath { get; set; }

        /// <summary>
        /// 散列方式签名密钥
        /// </summary>
        public string SecureKey { get; set; }

    }
}
