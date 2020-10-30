using OmniPay.Unionpay.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace OmniPay.Unionpay.Response
{
    public class FrontTransResponse
    {
        public FrontTransResponse(FrontTransRequest request)
        {
            Html = request.ToForm(request.RequestUrl);
        }

        /// <summary>
        /// 生成的Html网页
        /// </summary>
        public string Html { get; set; }

        public string Raw { get; set; }
    }
}
