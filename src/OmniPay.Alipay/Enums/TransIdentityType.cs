using System;
using System.Collections.Generic;
using System.Text;

namespace OmniPay.Alipay.Enums
{
    public enum TransIdentityType
    {
        /// <summary>
        /// 支付宝的会员ID
        /// </summary>
        ALIPAY_USER_ID,

        /// <summary>
        /// 支付宝登录号，支持邮箱和手机号格式
        /// </summary>
        ALIPAY_LOGON_ID
    }
}
