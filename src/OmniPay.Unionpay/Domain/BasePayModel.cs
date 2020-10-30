using System;
using System.Collections.Generic;
using System.Text;

namespace OmniPay.Unionpay.Domain
{
    public class BasePayModel
    {
        /// <summary>
        ///     商户订单号 商户代码merId、商户订单号orderId、订单发送时间txnTime三要素唯一确定一笔交易
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        ///    交易金额
        /// </summary>
        public string TxnAmt { get; set; }
    }
}
