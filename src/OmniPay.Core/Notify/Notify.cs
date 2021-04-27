using System;
using System.Collections.Generic;
using System.Text;

namespace OmniPay.Core.Notify
{
    public class Notify
    {
        #region 事件
        /// <summary>
        /// 支付通知验证成功时触发
        /// </summary>
        public event EventHandler<object> PaymentSucceed;
        #endregion
    }
}
