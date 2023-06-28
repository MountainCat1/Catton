using Catut.Application.Abstractions;
using Catut.Application.Errors;
using Catut.Application.Exceptions;

namespace Catut.Application.Services;

public class ApiExceptionMapper : IApiExceptionMapper
{
    public Exception Map(ApiException exception)
    {
        if (exception.StatusCode == 403)
            return new UnauthorizedError(exception.Response.Content?.Message);

        if (exception.StatusCode == 404)
            return new NotFoundError(exception.Response.Content?.Message);


        return exception;
    }
}