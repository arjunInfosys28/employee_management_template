using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Api.Middleware
{
    // Minimal middleware for interview/demo: checks for X-Api-Key header
    public class SimpleAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SimpleAuthMiddleware> _logger;

        public SimpleAuthMiddleware(RequestDelegate next, ILogger<SimpleAuthMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("X-Api-Key", out var apiKey) || string.IsNullOrWhiteSpace(apiKey))
            {
                _logger.LogWarning("Missing API key");
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Missing or invalid API key");
                return;
            }

            // In real apps validate against config or store
            await _next(context);
        }
    }
}
