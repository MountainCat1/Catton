using Catut.Application.Exceptions;

namespace Catut.Application.Abstractions;

public interface IApiExceptionMapper
{
    public Exception Map(ApiException exception); 
}