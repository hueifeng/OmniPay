namespace OmniPay.Alipay.Domain
{
    public class Goods
    {
        /// <summary>
        ///     商品编码
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     支付宝统一商品编号
        /// </summary>
        public string AlipayGoodsId { get; set; }

        /// <summary>
        ///     商品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     商品数量
        /// </summary>
        public int Quantity { get; set; }
        
        /// <summary>
        ///     商品单价，单位为元
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        ///     商品类目
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        ///     商品描述信息
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///     展品展示地址
        /// </summary>
        public string ShowUrl { get; set; }
    }
}
