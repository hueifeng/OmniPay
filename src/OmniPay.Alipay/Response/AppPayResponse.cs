using OmniPay.Alipay.Request;

namespace OmniPay.Alipay.Response
{
    public class AppPayResponse
    {
        public AppPayResponse(AppPayRequest request)
        {
            OrderInfo = request.ToUrl();
        }

        /// <summary>
        /// 用于唤起App的订单参数
        /// </summary>
        public string OrderInfo { get; set; }

        public string Raw { get; set; }
    }
}
