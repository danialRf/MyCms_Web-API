using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyCmsWebApi2.Infrastructure.Extensions
{
    public class ModelValidationFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.ModelState.ValidationState == ModelValidationState.Invalid)
                throw context.ModelState.ToPhoenixException();
            await next();
        }
    }
}
