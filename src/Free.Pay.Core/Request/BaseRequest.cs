using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Free.Pay.Core.Request
{
    public abstract class BaseRequest<TModel,Response> 
    {
        public string RequestUrl { get; set; }
        /// <summary>
        ///     获取所有Key-value形式的文本请求参数字典。
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, string> GetParameters()
        {
            throw new NotImplementedException("stack not Implement");
        }

    }
}
