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
                if (exception is ValidationException validationException)
                {
                    return new BadRequestObjectResult(validationException);
                }

                return new StatusCodeResult(500);
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
                if (exception is ValidationException validationException)
                {
                    return new BadRequestObjectResult(validationException);
                }

                return new StatusCodeResult(500);
            });
    }
    
    public static IActionResult ToOk<TResult, TContract>(
        this Result<Unit> result)
    {
        return result.Match<IActionResult>(
            Succ: obj =>
            {
                return new OkResult();
            },
            Fail: exception =>
            {
                if (exception is ValidationException validationException)
                {
                    return new BadRequestObjectResult(validationException);
                }

                return new StatusCodeResult(500);
            });
    }
}