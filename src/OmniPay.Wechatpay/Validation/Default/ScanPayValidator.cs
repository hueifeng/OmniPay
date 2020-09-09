using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OmniPay.Wechatpay.Validation.Default
{
    public class ScanPayValidator : IScanPayValidator
    {
        public async Task<ValidationResult> ValidateAsync(HttpContext context)
        {
            ValidationResult result = new ValidationResult();
            result.ErrorDescription = "≤‚ ‘∞°";
            result.Error = "¥ÌŒÛ¡À";
            return result;
        }
    }
}