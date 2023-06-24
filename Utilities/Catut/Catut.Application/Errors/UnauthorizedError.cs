namespace Catut.Application.Errors;

public class UnauthorizedError : ApplicationError
{
    public override int StatusCode => 401;

    public UnauthorizedError() : base("Access denied")
    {
    }
    public UnauthorizedError(string? message) : base(message)
    {
    }

    public UnauthorizedError(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}