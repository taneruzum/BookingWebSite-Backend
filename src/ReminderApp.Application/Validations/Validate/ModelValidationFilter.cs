using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReminderApp.Domain.Models;

namespace ReminderApp.Application.Validations.Validate
{
    public class ModelValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var apiError = new ErrorResponse
                {
                    StatusCode = 400,
                    StatusPhrase = "Bad Request",
                    TimeSpan = DateTime.Now,
                    Errors = new Dictionary<string, List<string>>() // List<string> kullanarak değişiklik
                };

                var errors = context.ModelState.AsEnumerable();

                foreach (var error in errors)
                {
                    foreach (var inn in error.Value.Errors)
                    {
                        if (!apiError.Errors.ContainsKey(error.Key))
                        {
                            apiError.Errors[error.Key] = new List<string>();
                        }
                        apiError.Errors[error.Key].Add(inn.ErrorMessage);
                    }
                }

                context.Result = new BadRequestObjectResult(apiError);
            }
        }
    }
}
