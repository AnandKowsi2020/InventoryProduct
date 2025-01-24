using System.Text;

namespace myTestWebApi.Middleware
{
    public class AuthMiddleware
    {
       
            private readonly RequestDelegate _next;

            public AuthMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task Invoke(HttpContext context)
            {
                if (!context.Request.Headers.ContainsKey("Authorization"))
                {
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync("Authorization header is missing.");
                    return;
                }

                var authHeader = context.Request.Headers["Authorization"].ToString();
                if (authHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
                {
                    var encodedCredentials = authHeader.Substring("Basic ".Length).Trim();
                    var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials)).Split(':');

                    var username = credentials[0];
                    var password = credentials[1];

                    // Validate credentials (hardcoded for simplicity)
                    if (username == "admin" && password == "password")
                    {
                        await _next(context); // Continue to the next middleware
                        return;
                    }
                }

                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Invalid username or password.");
            }
        }

    
}
