using Microsoft.AspNetCore.Http;
using OmniPay.Core.Hosting;
using System.Threading.Tasks;

namespace OmniPay.Core.Results
{
    public class ProccessErrorResult : IEndpointResult
    {
        public string Error;
        public string ErrorDescription;

        public ProccessErrorResult(string error, string errorDescription = null)
        {
            Error = error;
            ErrorDescription = errorDescription;
        }
         
        public Task ExecuteAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=UTF-8";
            context.Response.WriteAsync("{'test':'测试'}");
            context.Response.Body.FlushAsync();
            return Task.CompletedTask;
        }
    }
}
