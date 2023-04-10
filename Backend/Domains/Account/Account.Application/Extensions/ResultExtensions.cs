using FluentValidation;
using LanguageExt;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;

namespace Account.Application.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToOk<TResult, TContract>(
        this Result<TResult> result, Func<TResult, TContract> mapper)
    {
        return result.Match<IActionResult>(
            Succ: obj =>
            {
                var response = mapper(obj);
                return new OkObjectResult(response);
            },
            Fail: exception =>
            {
                return ProcessFail(exception);
            });
    }
    
    public static IActionResult ToOk<TResult>(
        this Result<TResult> result)
    {
        return result.Match<IActionResult>(
            Succ: obj =>
            {
                return new OkObjectResult(obj);
            },
            Fail: exception =>
            {
                return ProcessFail(exception);
            });
    }
    
    public static IActionResult ToOk(
        this Result<Unit> result)
    {
        return result.Match<IActionResult>(
            Succ: obj =>
            {
                return new OkResult();
            },
            Fail: exception =>
            {
                return ProcessFail(exception);
            });
    }

    private static IActionResult ProcessFail(Exception exception)
    {
        if (exception is ValidationException validationException)
        {
            return new BadRequestObjectResult(validationException);
        }
                
        if (exception is UnauthorizedAccessException ex)
        {
            return new UnauthorizedObjectResult(ex);
        }

        return new StatusCodeResult(500);
    }
}