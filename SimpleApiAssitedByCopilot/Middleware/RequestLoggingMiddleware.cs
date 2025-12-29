namespace SimpleApiAssitedByCopilot.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;
        public RequestLoggingMiddleware(ILogger logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Incoming request: {context.Request.Method} {context.Request.Path}");
            await _next(context);
            _logger.LogInformation($"Outgoing response: {context.Response.StatusCode}");
        }
    }
}
