using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Wecheer.Api.Filters
{
    public class ValidateModelStateFilter : IActionFilter
    {
        private static readonly HashSet<string> AllowMethods =
            new HashSet<string>(StringComparer.InvariantCultureIgnoreCase) { "PUT", "POST", "PATCH" };

        private static bool IsAllowedMethods(string methodName)
        {
            return AllowMethods.Contains(methodName);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!IsAllowedMethods(context.HttpContext.Request.Method))
            {
                return;
            }

            if (!context.ModelState.IsValid)
            {
                var errorMessage = context.ModelState.Values.FirstOrDefault(x => x.ValidationState == ModelValidationState.Invalid)?.Errors?.FirstOrDefault();
                var message = errorMessage?.Exception?.Message ?? errorMessage?.ErrorMessage;

                context.Result = new JsonResult(new
                {
                    Error = message
                })
                {
                    StatusCode = 400
                };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // not required
        }
    }
}