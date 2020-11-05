using OmniPay.Core.Request;
using OmniPay.Unionpay.Domain;
using OmniPay.Unionpay.Response;

namespace OmniPay.Unionpay.Request
{
    public class BackTransRequest : BaseRequest<BackTransModel, BackTransResponse>
    {
        public BackTransRequest()
        {
            RequestUrl = "/backTransReq.do";
        }
    }
}
