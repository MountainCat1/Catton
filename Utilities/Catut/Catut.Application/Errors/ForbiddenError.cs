using Catut.Application.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Catut.Application.Errors;

public class ForbiddenError : ApplicationError
{
    public override int StatusCode => 403;
    public override string ErrorName => "Forbidden";

    public ICollection<string> Failures { get; set; }
    
    public ForbiddenError() : base("Access denied")
    {
    }
    public ForbiddenError(string? message) : base(message)
    {
    }
    public ForbiddenError(IEnumerable<AuthorizationFailureReason> validationFailures) : base("Access denied")
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