namespace ApiGateway.Middleware;

public class ApiFallbackMiddleware : IMiddleware
{
    private async Task HandleRequestAsync(HttpContext httpContext)
    {
        await httpContext.Response.WriteAsync("This is a fallback response from Ocelot API Gateway");
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Get the incoming request URL
        var url = context.Request.Path.Value?.ToLower();

        // If URL is somehow null just continue
        if (url is null)
        {
            await next.Invoke(context);
            return;
        }

        // Check if the URL does not end with "/api"
        if (!url.StartsWith("/api"))
        {
            // Handle the request directly
            await HandleRequestAsync(context);
        }
        else
        {
            // Pass the request on to downstream microservices
            await next.Invoke(context);
        }
    }
}