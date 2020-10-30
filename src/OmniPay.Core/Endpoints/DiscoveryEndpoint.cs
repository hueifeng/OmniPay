using Microsoft.AspNetCore.Http;
using OmniPay.Core.Endpoints.Results;
using OmniPay.Core.Hosting;

namespace OmniPay.Core.Endpoints
{
    public class DiscoveryEndpoint : IEndpointHandler
    {
        public IEndpointResult Process(HttpContext context)
        {
            return new DiscoveryDocumentResult(DiscoveryResponseGenerator.DiscoveryDictionary);
        }
    }
}
