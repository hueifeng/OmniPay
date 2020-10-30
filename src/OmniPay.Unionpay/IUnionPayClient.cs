using OmniPay.Core.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OmniPay.Unionpay
{
    public interface IUnionPayClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<TResponse> ExecuteAsync<TModel, TResponse>(BaseRequest<TModel, TResponse> request);
    }
}
