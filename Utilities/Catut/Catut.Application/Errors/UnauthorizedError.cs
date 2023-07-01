namespace Catut.Application.Errors;

public class UnauthorizedError : ApplicationError
{
    public override int StatusCode => 401;
    public override string ErrorName => "Unauthorized";

    public UnauthorizedError() : base("Access denied")
    {
    }
    public UnauthorizedError(string? message) : base(message)
    {
    }
    
}