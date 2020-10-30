namespace OmniPay.Wechatpay
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
        ///     Merchant Id
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        ///     App Secret
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        ///     Notice the URL   
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        ///     Merchants public key
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        ///     BaseUrl
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        ///    The logical name of the <see cref="T:System.Net.Http.HttpClient" /> to configure.
        /// </summary>
        public string HttpClientName { get; set; }
    }
}
