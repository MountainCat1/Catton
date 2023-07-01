using Catut.Application.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Catut.Application.Errors;

public class UnauthorizedError : ApplicationError
{
    public override int StatusCode => 401;
    public override string ErrorName => "Unauthorized";

    public ICollection<string> Failures { get; set; }
    
    public UnauthorizedError() : base("Access denied")
    {
    }
    public UnauthorizedError(string? message) : base(message)
    {
    }
    public UnauthorizedError(IEnumerable<AuthorizationFailureReason> validationFailures) : base("Access denied")
    {
        Failures = validationFailures.Select(failure => failure.Message).ToList();
    }

    public override ErrorResponse GetErrorResponse()
    {
        return new ErrorResponse()
        {
            StatusCode = 401,
            Failures = Failures,
            Error = ErrorName,
            Message = Message
        };
    }
}