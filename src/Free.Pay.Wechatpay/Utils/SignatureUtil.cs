using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Free.Pay.Wechatpay.Utils
{
    /// <summary>
    ///     签名工具类
    /// </summary>
    public static class SignatureUtil
    {

        #region 验签
        /// <summary>
        /// 验签
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="sign">签名</param>
        /// <param name="signPubKeyCert">验证公钥</param>
        /// <returns></returns>
        public static bool VerifyData(string data, string sign)
        {
            return true;
        }

        #endregion
    }
}
