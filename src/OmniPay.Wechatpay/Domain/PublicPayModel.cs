using OmniPay.Core.Utils;

namespace OmniPay.Wechatpay.Domain
{
    public class PublicPayModel:BasePayModel
    {
        public PublicPayModel()
        {
            TradeType = "JSAPI";
        }
        /// <summary>
        ///     交易类型
        /// </summary>
        public string TradeType { get; set; }

        /// <summary>
        ///     机器IP
        /// </summary>
        public string SpbillCreateIp { get; set; } 
        /// <summary>
        ///     用户标识
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        ///     场景信息
        /// </summary>
        public string SceneInfo { get; set; }
    }
}
