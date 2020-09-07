using Newtonsoft.Json;

namespace OmniPay.Alipay.Response
{
    public abstract class BaseResponse
    {

        /// <summary>
        ///     返回状态码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///     返回码描述
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }

        /// <summary>
        ///     明细返回码
        /// </summary>
        public string SubCode { get; set; }

        /// <summary>
        ///     明细返回码描述
        /// </summary>
        [JsonProperty("sub_msg")]
        public string SubMessage { get; set; }

        /// <summary>
        ///     签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        ///     原始值
        /// </summary>
        public string Raw { get; set; }
    }
}
