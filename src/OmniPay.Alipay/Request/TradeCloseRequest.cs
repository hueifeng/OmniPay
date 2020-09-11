using OmniPay.Alipay.Domain;
using OmniPay.Alipay.Response;
using OmniPay.Core.Request;

namespace OmniPay.Alipay.Request
{
    public class TradeCloseRequest : BaseRequest<ScanPayModel, ScanPayResponse>
    {
        public TradeCloseRequest() 
        {
            RequestUrl = "/gateway.do?charset=UTF-8";
            Add("method", "alipay.trade.close");
        }
    }
}
