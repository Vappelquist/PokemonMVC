namespace PokemonMVC.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"I ErrorMiddleware: {context.Request.Path}");
            try
            {
                await _next(context);
            }
            catch (HttpRequestException)
            {
                context.Response.StatusCode = 503;
            }
            catch (TaskCanceledException)
            {
                context.Response.StatusCode = 503;
            }

            Console.WriteLine($"I ErrorMiddleware: {context.Response.StatusCode}");

            if (context.Response.StatusCode == 404 || context.Response.StatusCode == 503)
            {
                context.Items["Message"] = context.Response.StatusCode == 404
                    ? "This Pokemon could not be found"
                    : "PokéAPI seems to be unavailable at the moment";

                context.SetEndpoint(null);
                context.Request.RouteValues.Clear();
                context.Request.Path = "/Home/Error";

                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error rendering error page: {ex}");
                }
            }
        }
    }
}
