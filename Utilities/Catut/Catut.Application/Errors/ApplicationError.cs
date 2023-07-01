using Catut.Application.Dtos;

namespace Catut.Application.Errors;

public abstract class ApplicationError<TErrorResponse> : Exception
    where TErrorResponse : ErrorResponse
{
    protected ApplicationError()
    {
    }

    protected ApplicationError(string? message) : base(message)
    {
    }

    public abstract int StatusCode { get; }
    public abstract string ErrorName { get; }

    public abstract TErrorResponse GetErrorResponse();

}

public abstract class ApplicationError : ApplicationError<ErrorResponse>
{
    protected ApplicationError()
    {
    }

    protected ApplicationError(string? message) : base(message)
    {
    }

    public override ErrorResponse GetErrorResponse()
    {
        return new ErrorResponse()
        {
            StatusCode = StatusCode,
            Message = Message,
            Error = ErrorName
        };
    }
}
