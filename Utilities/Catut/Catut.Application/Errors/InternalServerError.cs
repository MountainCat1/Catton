namespace Catut.Application.Errors;

public class InternalServerError : ApplicationError
{
    public InternalServerError()
    {
    }

    public InternalServerError(string? message) : base(message)
    {
    }

    public override int StatusCode => 500;
    public override string ErrorName => "Internal Server Error";
}