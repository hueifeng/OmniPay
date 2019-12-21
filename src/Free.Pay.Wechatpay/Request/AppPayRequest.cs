using Free.Pay.Core.Request;
using Free.Pay.Wechatpay.Domain;
using Free.Pay.Wechatpay.Response;

namespace Free.Pay.Wechatpay.Request
{
    public class AppPayRequest : BaseRequest<AppPayModel, AppPayResponse>
    {
        public AppPayRequest()
        {
            RequestUrl = "/pay/unifiedorder";
        }
    }
}
