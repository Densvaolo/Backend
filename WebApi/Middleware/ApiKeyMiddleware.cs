namespace WebApi.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEYNAME = "X-Api-Key";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("X-Api-Key", out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key was not provided.");
                return;
            }

            var apiKey = Environment.GetEnvironmentVariable("ApiKey");
            Console.WriteLine("API key from env: " + apiKey);
            Console.WriteLine("API key from request: " + extractedApiKey);

            if (apiKey != extractedApiKey)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Wrong Api Key.");
                return;
            }

            await _next(context);
        }
    }
}
