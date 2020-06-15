using System;
using System.Collections.Generic;
using System.Text;

namespace Free.Pay.Alipay.Response
{
    public abstract class BaseResponse
    {

        /// <summary>
        ///     返回状态码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///     返回码描述
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     明细返回码
        /// </summary>
        public string SubCode { get; set; }

        /// <summary>
        ///     明细返回码描述
        /// </summary>
        public string SubMessage { get; set; }

        /// <summary>
        ///     签名
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        ///     原始值
        /// </summary>
        public string Raw { get; set; }
    }
}
