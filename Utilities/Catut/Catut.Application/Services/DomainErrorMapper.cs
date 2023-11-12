using Catut.Application.Abstractions;
using Catut.Application.Errors;
using Catut.Domain.Errors;

namespace Catut.Application.Services;

public class DomainErrorMapper : IDomainErrorMapper
{
    public Exception Map(Exception ex)
    {
        return ex switch
        {
            ValidationDomainError validationException => new BadRequestError(validationException.Errors),
            _ => ex
        };
    }
}