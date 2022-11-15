using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Tasking.Management.API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        private readonly IHttpContextAccessor _contextAcessor;

        public ValidationFilter(IHttpContextAccessor contextAcessor)
        {
            _contextAcessor = contextAcessor;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Method implemented because of the interface. Will not be used in this filter.
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorResponse = new ProblemDetails()
                {
                    Type = "https://example.com",
                    Title = "Bad Request",
                    Detail = "One or more validation errors ocurred.",
                    Instance = _contextAcessor.HttpContext!.Request.Path,
                    Status = 400
                };

                var errors = new Dictionary<string, List<string>>();

                foreach (var modelState in context.ModelState)
                {
                    var errorsMessages = modelState.Value.Errors
                        .Select(x => x.ErrorMessage)
                        .ToList();
                    errors.Add(modelState.Key.ToLower(), errorsMessages);
                }

                errorResponse.Extensions.Add("errors", errors);

                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }
    }
}
