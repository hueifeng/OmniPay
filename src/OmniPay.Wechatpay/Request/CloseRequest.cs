using OmniPay.Core.Request;
using OmniPay.Wechatpay.Domain;
using OmniPay.Wechatpay.Response;

namespace OmniPay.Wechatpay.Request
{
    public class CloseRequest : BaseRequest<CloseModel, CloseResponse>
    {
        public CloseRequest()
        {
            RequestUrl = "/pay/closeorder";
        }
        public override void Execute()
        {
            Remove("notify_url");
        }
    }
}
