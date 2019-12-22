using Free.Pay.Core.Request;
using Free.Pay.Wechatpay.Domain;
using Free.Pay.Wechatpay.Response;

namespace Free.Pay.Wechatpay.Request
{
    public class CloseRequest : BaseRequest<CloseModel, CloseResponse>
    {
        public CloseRequest()
        {
            RequestUrl = "/pay/closeorder";
        }
    }
}
