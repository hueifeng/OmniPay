using Free.Pay.Core.Request;
using Free.Pay.Wechatpay.Domain;
using Free.Pay.Wechatpay.Response;

namespace Free.Pay.Wechatpay.Request
{
    public class ScanPayRequest:BaseRequest<ScanPayModel, ScanPayResponse>
    {
        public ScanPayRequest()
        {
            RequestUrl = "/pay/unifiedorder";
        }
    }
}
