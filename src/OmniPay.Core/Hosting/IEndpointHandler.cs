using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OmniPay.Core.Hosting
{
    public interface IEndpointHandler
    {
        /// <summary>
        ///      Processes the request
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns></returns>
        IEndpointResult Process(HttpContext context);

    }
}
