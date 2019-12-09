using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Free.Pay.Core.Hosting
{
    public class EndpointRouter : IEndpointRouter
    {

        private readonly IEnumerable<Endpoint> _endpoints;
        private readonly ILogger _logger;

        public EndpointRouter(IEnumerable<Endpoint> endpoints, ILogger<EndpointRouter> logger)
        {
            _endpoints = endpoints;
            _logger = logger;
        }
        public IEndpointHandler Find(HttpContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            foreach (var endpoint in _endpoints)
            {
                var path = endpoint.Path;
                if (context.Request.Path.Equals(path, StringComparison.OrdinalIgnoreCase))
                {
                    var endpointName = endpoint.Name;
                    _logger.LogDebug("Request path {path} matched to endpoint type {endpoint}", context.Request.Path, endpointName);

                    return GetEndpointHandler(endpoint, context);
                }
            }
            _logger.LogTrace("No endpoint entry found for request path: {path}", context.Request.Path);

            return null;
        }

        private IEndpointHandler GetEndpointHandler(Endpoint endpoint, HttpContext context)
        {
            var handler = context.RequestServices.GetService(endpoint.Handler) as IEndpointHandler;
            if (handler != null)
            {
                _logger.LogDebug("Endpoint enabled: {endpoint}, successfully created handler: {endpointHandler}", endpoint.Name, endpoint.Handler.FullName);
                return handler;
            }
            else
            {
                _logger.LogDebug("Endpoint enabled: {endpoint}, failed to create handler: {endpointHandler}", endpoint.Name, endpoint.Handler.FullName);
            }

            return null;
        }
    }
}
