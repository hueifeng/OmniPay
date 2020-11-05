using OmniPay.Core.Request;
using OmniPay.Unionpay.Domain;
using OmniPay.Unionpay.Response;

namespace OmniPay.Unionpay.Request
{
    public class FrontTransRequest : BaseRequest<FrontTransModel, FrontTransResponse>
    {
        public FrontTransRequest()
        {
            RequestUrl = "/frontTransReq.do";
        }

    }
}
