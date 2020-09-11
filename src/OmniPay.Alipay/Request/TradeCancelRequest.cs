using OmniPay.Alipay.Domain;
using OmniPay.Alipay.Response;
using OmniPay.Core.Request;

namespace OmniPay.Alipay.Request
{
    public class TradeCancelRequest : BaseRequest<ScanPayModel, ScanPayResponse>
    {
        public TradeCancelRequest()
        {
            RequestUrl = "/gateway.do?charset=UTF-8";
            Add("method", "alipay.trade.cancel");
        }
    }
}
