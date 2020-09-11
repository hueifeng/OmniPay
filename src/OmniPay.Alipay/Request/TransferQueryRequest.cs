using OmniPay.Alipay.Domain;
using OmniPay.Alipay.Response;
using OmniPay.Core.Request;


namespace OmniPay.Alipay.Request
{
    public class TransferQueryRequest : BaseRequest<ScanPayModel, ScanPayResponse>
    {
        public TransferQueryRequest()
        {
            RequestUrl = "/gateway.do?charset=UTF-8";
            Add("method", "alipay.fund.trans.order.query");
        }
    }
}
