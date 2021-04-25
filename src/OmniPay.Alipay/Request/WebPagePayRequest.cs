using OmniPay.Alipay.Domain;
using OmniPay.Alipay.Response;
using OmniPay.Core.Request;

namespace OmniPay.Alipay.Request
{
    public class WebPagePayRequest : BaseRequest<WebPagePayRequest, WebPayResponse>
    {
        public WebPagePayRequest()
        {
            RequestUrl = "/gateway.do";
            Add("method", "alipay.trade.page.pay");
        }
    }
}
