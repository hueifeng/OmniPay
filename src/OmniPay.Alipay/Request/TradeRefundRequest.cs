using OmniPay.Alipay.Domain;
using OmniPay.Alipay.Response;
using OmniPay.Core.Request;

namespace OmniPay.Alipay.Request
{
    public class TradeRefundRequest : BaseRequest<ScanPayModel, ScanPayResponse>
    {
        public TradeRefundRequest()
        {
            RequestUrl = "/gateway.do?charset=UTF-8";
            Add("method", "alipay.trade.refund");
        }
    }
}
