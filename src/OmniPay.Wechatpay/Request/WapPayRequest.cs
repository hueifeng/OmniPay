using OmniPay.Core.Request;
using OmniPay.Wechatpay.Domain;
using OmniPay.Wechatpay.Response;

namespace OmniPay.Wechatpay.Request
{
    public class WapPayRequest : BaseRequest<WapPayModel, WapPayResponse>
    {
        public WapPayRequest()
        {
            RequestUrl = "/pay/unifiedorder";
        }
    }
}
