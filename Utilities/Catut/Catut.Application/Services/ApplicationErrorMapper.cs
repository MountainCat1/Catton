using Catut.Application.Abstractions;
using Catut.Application.Errors;
using FluentValidation;

namespace Catut.Application.Services;

public class ApplicationErrorMapper : IApplicationErrorMapper
{
    public Exception Map(Exception ex)
    {
        return ex switch
        {
            ValidationException validationException => new BadRequestError(validationException.Errors),
            InvalidOperationException invalidOperationException => new BadRequestError(invalidOperationException.Message),
            _ => ex
        };
    }
}