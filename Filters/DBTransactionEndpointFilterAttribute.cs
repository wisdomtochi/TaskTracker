using Microsoft.AspNetCore.Mvc.Filters;
using TaskTracker.Data.UnitOfWork.Interface;
using TaskTracker.Entities;

namespace TaskTracker.Filters
{
    public class DBTransactionEndpointFilterAttribute(ILogger<DBTransactionEndpointFilterAttribute> logger) : IEndpointFilter
    {
        private readonly ILogger<DBTransactionEndpointFilterAttribute> _logger = logger;

        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            try
            {
                return await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return Results.Problem("An error occurred. Please try again later while we fix it.");
            }
        }
    }
}
