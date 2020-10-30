using OmniPay.Core.Request;
using OmniPay.Unionpay.Domain;
using OmniPay.Unionpay.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OmniPay.Unionpay.Request
{
    public class BackTransRequest : BaseRequest<BackTransModel, BaseResponse>
    {
        public BackTransRequest()
        {
            RequestUrl = "/backTransReq.do";
        }
    }
}
