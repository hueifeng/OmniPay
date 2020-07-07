using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OmniPay.Wechatpay.Validation.Default
{
    public class ScanPayValidator : IScanPayValidator
    {
        public Task ValidateAsync(IFormCollection parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}