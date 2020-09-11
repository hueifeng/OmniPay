using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OmniPay.Alipay.Enums
{
    /// <summary>
    /// 转账业务产品代码
    /// </summary>
    public enum TransProductCode
    {
        /// <summary>
        /// 单笔无密转账到支付宝账户
        /// </summary>
        TRANS_ACCOUNT_NO_PWD,

        /// <summary>
        /// 单笔无密转账到银行卡
        /// </summary>
        TRANS_BANKCARD_NO_PWD,

        /// <summary>
        /// 收发现金红包
        /// </summary>
        STD_RED_PACKET
    }
}
