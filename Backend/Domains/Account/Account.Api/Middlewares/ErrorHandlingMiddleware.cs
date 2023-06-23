using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Account.Service.Errors;
using BaseApp.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Account.Application.Middlewares;

public class ErrorHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ErrorHandlingMiddleware> _logger;
    private readonly IDatabaseErrorMapper _databaseErrorMapper;

    public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger, IDatabaseErrorMapper databaseErrorMapper)
    {
        _logger = logger;
        _databaseErrorMapper = databaseErrorMapper;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (DatabaseException databaseException)
        {
            var error = await _databaseErrorMapper.MapAsync(databaseException);
            await HandleExceptionAsync(context, error);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        switch (ex)
        {
            case NotFoundError error:
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(error.Message);
                break;
            case UnauthorizedError error:
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(error.Message);
                break;
            case FluentValidation.ValidationException:
            case ValidationException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(ex.Message);
                break;
            default:
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Something went wrong");
                break;
        }
    }
}