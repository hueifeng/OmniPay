using OmniPay.Alipay.Domain;
using OmniPay.Alipay.Response;
using OmniPay.Core.Request;

namespace OmniPay.Alipay.Request
{
    public class TradeQueryRequest : BaseRequest<ScanPayModel, ScanPayResponse>
    {
        public TradeQueryRequest() 
        {
            RequestUrl = "/gateway.do?charset=UTF-8";
            Add("method", "alipay.trade.query");
        }
    }
}
