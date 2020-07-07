using Microsoft.AspNetCore.Http;

namespace OmniPay.Core.Hosting
{
    /// <summary>
    ///     The endpoint router
    /// </summary>
    public interface IEndpointRouter
    {
        /// <summary>
        /// Finds a matching endpoint.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns></returns>
        IEndpointHandler Find(HttpContext context);
    }
}
