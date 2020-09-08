using System.Collections.Generic;

namespace OmniPay.Alipay.Domain
{
    /// <summary>
    ///     电脑网站支付
    /// </summary>
    public class WebPayModel : BasePayModel
    {
        /// <summary>
        ///     订单包含的商品列表信息
        /// </summary>
        public List<Goods> GoodsDetail { get; set; }
    }
}
