using Free.Pay.Core.Request;
using Free.Pay.Wechatpay.Domain;
using Free.Pay.Wechatpay.Response;

namespace Free.Pay.Wechatpay.Request
{
    public class QueryRequest:BaseRequest<QueryModel,QueryResponse>
    {
        public QueryRequest()
        {
            RequestUrl = "/pay/orderquery";
        }

    }
}
