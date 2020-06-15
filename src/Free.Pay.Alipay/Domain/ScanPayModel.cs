using System.Collections.Generic;

namespace Free.Pay.Alipay.Domain
{
    public class ScanPayModel
    {
        /// <summary>
        ///     商户订单号,64个字符以内、可包含字母、数字、下划线；需保证在商户端不重复
        /// </summary>
        public string OutTradeNo { get; set; }

        /// <summary>
        ///     卖家编码，如果该值为空，则默认为商户签约账号对应的支付宝用户ID
        /// </summary>
        public string SellerId { get; set; }

        /// <summary>
        ///     订单总金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000]
        /// </summary>
        public double TotalAmount { get; set; }

        /// <summary>
        ///     参与优惠计算的金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000]。
        /// </summary>
        public double DiscountableAmount { get; set; }

        /// <summary>
        ///     订单标题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        ///     订单包含的商品列表信息
        /// </summary>
        public List<Goods> GoodsDetail { get; set; }

        /// <summary>
        ///     订单描述
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///   卖家端自定义的的操作员编号  
        /// </summary>
        public string OperatorId { get; set; }

        /// <summary>
        ///  商户门店编号
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        ///  禁用渠道，用户不可用指定渠道支付,当有多个渠道时用“,”分隔
        /// </summary>
        public string DisablePayChannels { get; set; }

        /// <summary>
        ///  可用渠道，用户只能在指定渠道范围内支付,当有多个渠道时用“,”分隔
        /// </summary>
        public string EnablePayChannels { get; set; }

        /// <summary>
        ///     商户的终端编号
        /// </summary>
        public string TerminalId { get; set; }

        /// <summary>
        ///     	该笔订单允许的最晚付款时间，逾期将关闭交易。
        /// 取值范围：1m～15d。m-分钟，h-小时，d-天，1c-当天（1c-当天的情况下，无论交易何时创建，都在0点关闭）。
        /// 该参数数值不接受小数点， 如 1.5h，可转换为 90m
        /// </summary>
        public string TimeoutExpress { get; set; }

        /// <summary>
        ///  商户传入业务信息，具体值要和支付宝约定
        /// 将商户传入信息分发给相应系统，应用于安全，营销等参数直传场景
        /// 格式为json格式
        /// </summary>
        public string BusinessParams { get; set; }
    }
}
