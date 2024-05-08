namespace TravelCompanionApp.exception;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

public class ValidationExceptionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(e => e.Value.Errors.Any())
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage)
                );

            var result = new ObjectResult(new
            {
                title = "Validation errors",
                status = 400,
                errors
            });

            result.StatusCode = 400;
            context.Result = result;
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Not needed for this example
    }
}
