using Newtonsoft.Json;

namespace GameZone.Api.Middleware
{
    public class ExpiredTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public ExpiredTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Response.Headers["Token-Expired"] == "True")
            {
                context.Response.StatusCode = 401;
                context.Response.Headers.Add("Content-Type", "application/json");
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    Error = "Token has expired",
                }));
                await context.Response.CompleteAsync();
            }
            else
            {
                await _next(context);
            }
        }
    }
}
