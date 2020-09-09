using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OmniPay.Wechatpay.Validation
{
    public interface IScanPayValidator
    {
        Task<ValidationResult> ValidateAsync(HttpContext context);
    }
}