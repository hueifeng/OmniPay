using OmniPay.Core.Request;
using OmniPay.Wechatpay.Domain;
using OmniPay.Wechatpay.Response;

namespace OmniPay.Wechatpay.Request
{
    public class AppPayRequest : BaseRequest<AppPayModel, AppPayResponse>
    {
        public AppPayRequest()
        {
            RequestUrl = "/pay/unifiedorder";
        }
    }
}
