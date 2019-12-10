namespace Free.Pay.Wechatpay
{
    public class WeChatPayOptions
    {
        /// <summary>
        ///   Application ID
        /// </summary>
        public string AppId { get; set; }
        /// <summary>
        ///     Signature type
        /// </summary>
        public string SignType=>"MD5";
        /// <summary>
        ///    WeChat pay API keys
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        ///     App Secret
        /// </summary>
        public string AppSecret { get; set; }
        /// <summary>
        ///     certificate path
        /// </summary>
        public string SslCertPath { get; set; }
        /// <summary>
        ///     Certificate password
        /// </summary>
        public string SslCertPassword { get; set; }
        /// <summary>
        ///     Notice the URL   
        /// </summary>
        public string NotifyUrl { get; set; }
        /// <summary>
        ///     Merchants public key
        /// </summary>
        public string PublicKey { get; set; }
    }
}
