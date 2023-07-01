using Catut.Application.Dtos;
using FluentValidation.Results;

namespace Catut.Application.Errors;

public class BadRequestError : ApplicationError
{
    public override int StatusCode => 404;
    public override string ErrorName => "Bad Request";
    
    public Dictionary<string, string> Errors { get; }
    

    public BadRequestError() : base()
    {
        
    }
    public BadRequestError(string? message) : base(message)
    {
        
    }
    
    public BadRequestError(IEnumerable<ValidationFailure> validationFailures) : base("Validation failed")
    {
        Errors = validationFailures.ToDictionary(x => x.PropertyName, x => x.ErrorMessage);
    }

    public override ErrorResponse GetErrorResponse()
    {
        return new ErrorResponse()
        {
            StatusCode = 400,
            Errors = Errors,
            Error = ErrorName,
            Message = Message
        };
    }
}