using OmniPay.Core.Request;
using OmniPay.Wechatpay.Domain;
using OmniPay.Wechatpay.Response;

namespace OmniPay.Wechatpay.Request
{
    public class PublicPayRequest:BaseRequest<PublicPayModel,PublicPayResponse>
    {
        public PublicPayRequest()
        {
            RequestUrl = "/pay/unifiedorder";
        }
    }
}
