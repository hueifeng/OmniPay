using OmniPay.Alipay.Response;
using OmniPay.Core.Request;

namespace OmniPay.Alipay.Request
{
    public class WapPayRequest : BaseRequest<WapPayRequest, WebPayResponse>
    {
        public WapPayRequest()
        {
            RequestUrl = "/gateway.do?charset=UTF-8";
            Add("method", "alipay.trade.wap.pay");
        }
    }
}
