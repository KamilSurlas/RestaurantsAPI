
using System.Diagnostics;

namespace Restaurants.API.Middlewares
{
    public class RequestTimeMiddleware(ILogger<RequestTimeMiddleware> _logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var stopwatch = Stopwatch.StartNew();
            await next.Invoke(context);
            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds / 1000 > 5)
            {
                _logger.LogInformation("Request [{Verb}] at {Path} took {Time} ms",
                    context.Request.Method,
                    context.Request.Path,
                    stopwatch.ElapsedMilliseconds);
            }
        }
    }
}
