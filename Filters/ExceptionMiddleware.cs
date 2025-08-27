using System.Net;

namespace TaskTracker.Filters
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                await httpContext.Response.WriteAsJsonAsync(new
                {
                    Status = false,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "An error occurred. It's not your fault. Please try again later while we fix it.",
                });
            }
        }
    }
}
