using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Catut.Application.Abstractions;
using Catut.Application.Dtos;
using Catut.Application.Errors;
using Catut.Application.Exceptions;
using Catut.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Catut.Application.Middlewares;

public class ErrorHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ErrorHandlingMiddleware> _logger;
    
    private readonly IDatabaseErrorMapper _databaseErrorMapper;
    private readonly IApiExceptionMapper _apiExceptionMapper;

    public ErrorHandlingMiddleware(
        ILogger<ErrorHandlingMiddleware> logger,
        IDatabaseErrorMapper databaseErrorMapper,
        IApiExceptionMapper apiExceptionMapper)
    {
        _logger = logger;
        _databaseErrorMapper = databaseErrorMapper;
        _apiExceptionMapper = apiExceptionMapper;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (DatabaseException databaseException)
        {
            var error = _databaseErrorMapper.Map(databaseException);
            await HandleExceptionAsync(context, error);
        }
        catch (ApiException apiException)
        {
            var error = _apiExceptionMapper.Map(apiException);
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
                await context.Response.WriteAsync(JsonSerializer.Serialize(ex.Message));
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
            Content = applicationError.ToErrorContent()
        };
        return JsonSerializer.Serialize(errorResponse);
    }
}