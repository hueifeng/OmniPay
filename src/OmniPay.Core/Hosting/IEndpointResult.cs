using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OmniPay.Core.Hosting
{
    /// <summary>
    ///     Endpoint result
    /// </summary>
    public interface IEndpointResult
    {
        /// <summary>
        ///     Executes the result
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns></returns>
        Task ExecuteAsync(HttpContext context);
    }
}
