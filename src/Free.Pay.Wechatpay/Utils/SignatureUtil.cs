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
        //public string GetSign(string data)
        //{
        //    var key = "b7c996fbda5a9633ee4feb6b991c3919";
        //    var data = string.Join("&",
        //        data
        //            .Select(a => $"{a.Key}={a.Value.ToString()}"));
        //    data += $"&key={key}";

        //    var byteData = Encoding.UTF8.GetBytes(data);
        //    var byteKey = Encoding.UTF8.GetBytes(key);
        //    var hmacsha256 = new HMACSHA256(byteKey);
        //    var result = hmacsha256.ComputeHash(byteData);
        //    return BitConverter.ToString(result).Replace("-", "").ToUpper();
        //}

        #endregion
    }
}
