using Microsoft.AspNetCore.Mvc;
using OmniPay.Core.Utils;
using OmniPay.Unionpay;
using OmniPay.Unionpay.Domain;
using OmniPay.Unionpay.Request;
using System.Threading.Tasks;

namespace OmniPay.Pay.Controllers
{
    public class UnionPayController : ControllerBase
    {
        private readonly IUnionPayClient _client;

        public UnionPayController(IUnionPayClient client)
        {
            this._client = client;
        }

        /// <summary>
        ///     跳转网关页面支付
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<OkObjectResult> FrontTrans(string txnAmt, string orderId)
        {
            var request = new FrontTransRequest();
            request.AddParameters(new FrontTransModel
            {
                TxnAmt = txnAmt,
                OrderId = orderId
            }, StringCase.Camel);
            return Ok(await _client.ExecuteAsync(request));
        }

        /// <summary>
        ///     消费撤销接口
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<OkObjectResult> BackTrans(string txnAmt, string orderId)
        {
            var request = new BackTransRequest();
            request.AddParameters(new BackTransModel
            {
                TxnAmt = txnAmt,
                OrderId = orderId,
            }, StringCase.Camel);
            return Ok(await _client.ExecuteAsync(request));
        }

    }
}
