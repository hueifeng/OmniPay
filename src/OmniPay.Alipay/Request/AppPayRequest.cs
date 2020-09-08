using OmniPay.Alipay.Domain;
using OmniPay.Alipay.Response;
using OmniPay.Core.Request;

namespace OmniPay.Alipay.Request
{
    public class AppPayRequest : BaseRequest<AppPayModel, AppPayResponse>
    {
        public AppPayRequest()
        {
            RequestUrl = "/gateway.do?charset=UTF-8";
            Add("method", "alipay.trade.app.pay");
        }
    }
}
