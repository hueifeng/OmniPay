using OmniPay.Alipay.Domain;
using OmniPay.Alipay.Response;
using OmniPay.Core.Request;

namespace OmniPay.Alipay.Request
{
    public class ScanPayRequest: BaseRequest<ScanPayModel,ScanPayResponse>
    {
        public ScanPayRequest()
        {
            RequestUrl = "/gateway.do?charset=UTF-8";
            Add("method", "alipay.trade.precreate");
        }
    }
}
