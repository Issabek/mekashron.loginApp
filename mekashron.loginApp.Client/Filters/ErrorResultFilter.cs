using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using mekashron.loginApp.Client.Models;
using Newtonsoft.Json.Linq;

namespace mekashron.loginApp.Client.Filters
{
    public class ErrorResultFilter : IAsyncResultFilter
    {
        public Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as ObjectResult;
            var response = result?.Value as Response;
            if (response != null)
                context.HttpContext.Response.StatusCode
                    = response.Errors.Any(x => x.Equals("SomeError")) ? 400 : 200;
            return next();
        }
    }
}
