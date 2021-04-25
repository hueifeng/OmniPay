using OmniPay.Alipay.Request;

namespace OmniPay.Alipay.Response
{
    public class WebPayResponse
    {
        public WebPayResponse(WapPayRequest request)
        {
            Html = request.ToForm(request.RequestUrl);
        }

        public WebPayResponse(WebPagePayRequest request)
        {
            Html = request.ToForm(request.RequestUrl);
        }

        /// <summary>
        /// 生成的Html网页
        /// </summary>
        public string Html { get; set; }

        public string Raw { get; set; }

    }
}
