using OmniPay.Core.Request;
using OmniPay.Wechatpay.Domain;
using OmniPay.Wechatpay.Response;

namespace OmniPay.Wechatpay.Request
{
    public class QueryRequest:BaseRequest<QueryModel,QueryResponse>
    {
        public QueryRequest()
        {
            RequestUrl = "/pay/orderquery";
        }
        public override void Execute()
        {
            Remove("notify_url");
        }
    }
}
