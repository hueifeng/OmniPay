using Free.Pay.Core.Request;
using Free.Pay.Wechatpay.Domain;
using Free.Pay.Wechatpay.Response;

namespace Free.Pay.Wechatpay.Request
{
    public class PublicPayRequest:BaseRequest<PublicPayModel,PublicPayResponse>
    {
        public PublicPayRequest()
        {
            RequestUrl = "/pay/unifiedorder";
        }
    }
}
