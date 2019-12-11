using System.Threading.Tasks;

namespace Free.Pay.Core.Request
{
    public abstract class BaseRequest<TModel,Response> 
    {
        public string RequestUrl { get; set; }
    }
}
