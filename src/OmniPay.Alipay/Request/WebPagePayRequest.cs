using OmniPay.Alipay.Domain;
using OmniPay.Alipay.Response;
using OmniPay.Core.Request;

namespace OmniPay.Alipay.Request
{
    public class WebPagePayRequest:BaseRequest<ScanPayModel, WebPayResponse>
    {
        public WebPagePayRequest()
        {
            RequestUrl = "/gateway.do?charset=UTF-8";
            Add("method", "alipay.trade.page.pay");
        }
    }
}
