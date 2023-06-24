namespace Catut.Application.Errors;

public class NotFoundError : ApplicationError
{
    public override int StatusCode => 404;

    public NotFoundError() : base("Item not found")
    {
        
    }
    public NotFoundError(string? message) : base(message)
    {
        
    }

    public NotFoundError(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}