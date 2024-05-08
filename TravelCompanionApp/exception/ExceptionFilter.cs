using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TravelCompanionApp.exception;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ExceptionFilter : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        var response = context.HttpContext.Response;

        response.ContentType = "application/json";

        if (exception is ResourceNotFoundException)
        {
            response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Result = new JsonResult(new { message = exception.Message });
        }
        else if (exception is InvalidRequestException)
        {
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            var ex = exception as InvalidRequestException;
            context.Result = new JsonResult(new { message = exception.Message, errors = ex.Errors });
        }
        else
        {
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(new { message = "Internal Server Error" });
        }

        context.ExceptionHandled = true;
    }
}