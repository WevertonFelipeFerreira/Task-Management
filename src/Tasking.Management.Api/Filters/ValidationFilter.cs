using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using static Tasking.Management.CrossCutting.ProblemDetail.ErrorGenerator;

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
            var errors = new Dictionary<string, List<string>>();

            foreach (var modelState in context.ModelState)
            {
                var errorsMessages = modelState.Value.Errors
                    .Select(x => x.ErrorMessage)
                    .ToList();
                errors.Add(modelState.Key.ToLower(), errorsMessages);
            }
            context.Result = new BadRequestObjectResult(
                GetProblemDetails("Bad Request", "One or more validation errors ocurred.", 400, _contextAcessor)
                    .SetExtension("errors", errors));
        }
    }
}
