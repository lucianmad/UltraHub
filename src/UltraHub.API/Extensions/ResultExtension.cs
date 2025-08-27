using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UltraHub.Application.Common.Errors;
using UltraHub.Application.Common.Models;

namespace UltraHub.API.Extensions;

public static class ResultExtension
{
    public static IActionResult ToActionResult(this Result result, ControllerBase controller)
    {
        return result.IsSuccess
            ? controller.Ok()
            : HandleError(result.Error!, controller);
    }

    public static IActionResult ToActionResult<T>(this Result<T> result, ControllerBase controller)
    {
        return result.IsSuccess
            ? controller.Ok(result.Value)
            : HandleError(result.Error!, controller);
    }

    public static IActionResult HandleError(Error error, ControllerBase controller)
    {
        var response = CreateErrorResponse(error);

        return error.Type switch
        {
            ErrorType.Validation => controller.BadRequest(response),
            ErrorType.NotFound => controller.NotFound(response),
            ErrorType.Conflict => controller.Conflict(response),
            ErrorType.Unauthorized => controller.Unauthorized(response),
            _ => controller.StatusCode(500, response),
        };
    }

    public static object CreateErrorResponse(Error error)
    {
        if (error.Type == ErrorType.Validation && error.FieldErrors != null)
        {
            return new
            {
                Error = new
                {
                    error.Code,
                    error.Message,
                    error.FieldErrors
                }
            };
        }

        return new
        {
            Error = new
            {
                error.Code,
                error.Message
            }
        };
    }
}
