using OmniPay.Unionpay.Request;

namespace OmniPay.Unionpay.Response
{
    public class BackTransResponse
    {
        public BackTransResponse(BackTransRequest request)
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
