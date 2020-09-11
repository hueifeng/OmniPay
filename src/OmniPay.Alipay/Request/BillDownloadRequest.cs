using OmniPay.Alipay.Domain;
using OmniPay.Alipay.Response;
using OmniPay.Core.Request;

namespace OmniPay.Alipay.Request
{
    public class BillDownloadRequest : BaseRequest<ScanPayModel, ScanPayResponse>
    {
        public BillDownloadRequest() 
        {
            RequestUrl = "/gateway.do?charset=UTF-8";
            Add("method", "alipay.data.dataservice.bill.downloadurl.query");
        }
    }
}
