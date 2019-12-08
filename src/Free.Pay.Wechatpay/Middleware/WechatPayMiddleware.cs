using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AspNetCore.Free.Pay
{
    public class WechatPayMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public WechatPayMiddleware(RequestDelegate next, ILogger<WechatPayMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                _logger.LogInformation("Invoking endpoint:  {url}", context.Request.Path.ToString());
            }
            catch (Exception)
            {

                throw;
            }
            await context.Response.WriteAsync("`");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class WechatPayMiddlewareExtensions
    {
        public static IApplicationBuilder UseWechatPayMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WechatPayMiddleware>();
        }
    }
}
