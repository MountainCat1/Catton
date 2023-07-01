namespace Catut.Application.Errors;

public class NotFoundError : ApplicationError
{
    public override int StatusCode => 404;
    public override string ErrorName => "Not Found";

    public NotFoundError() : base("Item not found")
    {
        
    }
    public NotFoundError(string? message) : base(message)
    {
        
    }
}