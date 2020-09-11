using OmniPay.Alipay.Domain;
using OmniPay.Alipay.Response;
using OmniPay.Core.Request;


namespace OmniPay.Alipay.Request
{
    public class RefundQueryRequest : BaseRequest<ScanPayModel, ScanPayResponse>
    {
        public RefundQueryRequest()
        {
            RequestUrl = "/gateway.do?charset=UTF-8";
            Add("method", "alipay.trade.fastpay.refund.query");
        }
    }
}
