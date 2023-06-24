using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Account.Service.Dtos;
using Account.Service.Errors;
using Account.Service.Services;
using BaseApp.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Account.Application.Middlewares;

public class ErrorHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ErrorHandlingMiddleware> _logger;
    private readonly IDatabaseErrorMapper _databaseErrorMapper;
    private readonly IJsonSerializer _serializer;

    public ErrorHandlingMiddleware(
        ILogger<ErrorHandlingMiddleware> logger,
        IDatabaseErrorMapper databaseErrorMapper,
        IJsonSerializer serializer)
    {
        _logger = logger;
        _databaseErrorMapper = databaseErrorMapper;
        _serializer = serializer;
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
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(SerializeError(error));
                break;
            case UnauthorizedError error:
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(SerializeError(error));
                break;
            case FluentValidation.ValidationException:
            case ValidationException:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(_serializer.Serialize(ex.Message));
                break;
            default:
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Something went wrong");
                break;
        }
    }

    private string SerializeError(ApplicationError applicationError)
    {
        var errorResponse = new ErrorResponse()
        {
            ErrorContent = applicationError.ToError()
        };
        return _serializer.Serialize(errorResponse);
    }
}