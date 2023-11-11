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
    private readonly IApplicationErrorMapper _applicationErrorMapper;

    public ErrorHandlingMiddleware(
        ILogger<ErrorHandlingMiddleware> logger,
        IDatabaseErrorMapper databaseErrorMapper,
        IApiExceptionMapper apiExceptionMapper,
        IApplicationErrorMapper applicationErrorMapper)
    {
        _logger = logger;
        _databaseErrorMapper = databaseErrorMapper;
        _apiExceptionMapper = apiExceptionMapper;
        _applicationErrorMapper = applicationErrorMapper;
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
            var mappedException = _applicationErrorMapper.Map(ex);
            await HandleExceptionAsync(context, mappedException);
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
            case BadRequestError error:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(SerializeError(error));
                break;
            default:
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var reponseText = SerializeError(new InternalServerError("Something went wrong"));
                await context.Response.WriteAsync(reponseText);
                break;
        }
    }

    private string SerializeError<TErrorResponse>(ApplicationError<TErrorResponse> applicationError)
        where TErrorResponse : ErrorResponse
    {
        return JsonSerializer.Serialize(applicationError.GetErrorResponse());
    }
}