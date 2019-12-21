using Free.Pay.Core.Request;
using Free.Pay.Wechatpay.Domain;
using Free.Pay.Wechatpay.Response;

namespace Free.Pay.Wechatpay.Request
{
    public class AppletPayRequest : BaseRequest<AppletPayModel, AppletPayResponse>
    {
        public AppletPayRequest()
        {
            RequestUrl = "/pay/unifiedorder";
        }
    }
}
