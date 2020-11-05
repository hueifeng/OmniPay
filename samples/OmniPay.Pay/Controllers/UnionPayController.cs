using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OmniPay.Core.Utils;
using OmniPay.Unionpay;
using OmniPay.Unionpay.Domain;
using OmniPay.Unionpay.Request;

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
        public async Task<OkObjectResult> FrontTrans(string TxnAmt, string OrderId)
        {
            var request = new FrontTransRequest();
            request.AddParameters(new FrontTransModel
            {
                TxnAmt = TxnAmt,
                OrderId = OrderId,
            }, StringCase.Camel);
            return Ok(await _client.ExecuteAsync(request));
        }

        /// <summary>
        ///     消费撤销接口
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<OkObjectResult> BackTrans(string TxnAmt, string OrderId)
        {
            var request = new BackTransRequest();
            request.AddParameters(new BackTransModel
            {
                TxnAmt = TxnAmt,
                OrderId = OrderId,
            }, StringCase.Camel);
            return Ok(await _client.ExecuteAsync(request));
        }

    }
}
