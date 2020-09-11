using System;
using System.Collections.Generic;
using System.Text;

namespace OmniPay.Alipay.Enums
{
    public enum BillType
    {
        /// <summary>
        /// 商户基于支付宝交易收单的业务账单
        /// </summary>
        Trade,

        /// <summary>
        /// 于商户支付宝余额收入及支出等资金变动的帐务账单
        /// </summary>
        SignCustomer
    }
}
