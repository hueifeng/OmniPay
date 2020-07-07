using OmniPay.Core.Request;
using OmniPay.Wechatpay.Domain;
using OmniPay.Wechatpay.Response;

namespace OmniPay.Wechatpay.Request
{
    public class AppletPayRequest : BaseRequest<AppletPayModel, AppletPayResponse>
    {
        public AppletPayRequest()
        {
            RequestUrl = "/pay/unifiedorder";
        }
    }
}
