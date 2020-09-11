using OmniPay.Alipay.Domain;
using OmniPay.Alipay.Response;
using OmniPay.Core.Request;


namespace OmniPay.Alipay.Request
{
    public class TransferRequest : BaseRequest<ScanPayModel, ScanPayResponse>
    {
        public TransferRequest() 
        {
            RequestUrl = "/gateway.do?charset=UTF-8";
            Add("method", "alipay.fund.trans.uni.transfer");
        }
    }
}
