using System;
using System.Collections.Generic;
using System.Text;

namespace OmniPay.Alipay.Domain
{
    public class Payee
    {
        /// <summary>
        /// 收款方的唯一标识
        /// </summary>
        public string identity { get; set; }

        /// <summary>
        /// 收款方的唯一标识
        /// </summary>
        public string identity_type { get; set; }

        /// <summary>
        /// 参与方真实姓名，如果非空，将校验收款支付宝账号姓名一致性。当identity_type=ALIPAY_LOGON_ID时，本字段必填。
        /// </summary>
        public string name { get; set; }
    }
}
