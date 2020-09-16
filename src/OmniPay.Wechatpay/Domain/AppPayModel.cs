using OmniPay.Core.Utils;

namespace OmniPay.Wechatpay.Domain
{
    public class AppPayModel:BasePayModel
    {
        public AppPayModel()
        {
            TradeType = "APP";
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
