using OmniPay.Core.Request;
using OmniPay.Wechatpay.Domain;
using OmniPay.Wechatpay.Response;

namespace OmniPay.Wechatpay.Request
{
    public class ScanPayRequest:BaseRequest<ScanPayModel, ScanPayResponse>
    {
        public ScanPayRequest()
        {
            RequestUrl = "/pay/unifiedorder";
        }
    }
}
