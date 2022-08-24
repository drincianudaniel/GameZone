namespace GameZone.Api.Middleware
{
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<Middleware> _logger;
        public Middleware(RequestDelegate next, ILogger<Middleware> logger)
        {
            _next=next;
            _logger=logger;
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("request in");
            await _next(context);
            _logger.LogInformation("request out");
        } 
    }
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
