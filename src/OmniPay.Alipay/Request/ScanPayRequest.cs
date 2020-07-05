using Free.Pay.Alipay.Domain;
using Free.Pay.Alipay.Response;
using Free.Pay.Core.Request;

namespace Free.Pay.Alipay.Request
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
