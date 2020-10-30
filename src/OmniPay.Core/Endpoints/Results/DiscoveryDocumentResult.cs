using Microsoft.AspNetCore.Http;
using OmniPay.Core.Hosting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OmniPay.Core.Utils;

namespace OmniPay.Core.Endpoints.Results
{
    /// <summary>
    /// Result for a discovery document
    /// <seealso cref="https://github.com/IdentityServer/IdentityServer4/blob/main/src/IdentityServer4/src/Endpoints/Results/DiscoveryDocumentResult.cs"/>
    /// </summary>
    public class DiscoveryDocumentResult : IEndpointResult
    {
        /// <summary>
        /// Gets the entries.
        /// </summary>
        /// <value>
        /// The entries.
        /// </value>
        public Dictionary<string, object> Entries { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscoveryDocumentResult" /> class.
        /// </summary>
        /// <param name="entries">The entries.</param>
        /// <exception cref="System.ArgumentNullException">entries</exception>
        public DiscoveryDocumentResult(Dictionary<string, object> entries)
        {
            Entries = entries ?? throw new ArgumentNullException(nameof(entries));
        }

        /// <summary>
        /// Executes the result.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns></returns>
        public Task ExecuteAsync(HttpContext context)
        {
            return context.Response.WriteAsync(Entries.ToJson());
        }
    }
}
