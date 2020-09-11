using System;
using System.Collections.Generic;
using System.Text;

namespace OmniPay.Alipay.Enums
{
    public enum TransBizScene
    {
        /// <summary>
        /// 单笔无密转账到支付宝/银行卡, B2C现金红包
        /// </summary>
        DIRECT_TRANSFER,

        /// <summary>
        /// C2C现金红包-领红包
        /// </summary>
        PERSONAL_COLLECTION
    }
}
