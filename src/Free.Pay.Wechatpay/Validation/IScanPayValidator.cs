using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Free.Pay.Wechatpay.Validation
{
    public interface IScanPayValidator
    {
         Task ValidateAsync(IFormCollection parameters);
    }
}