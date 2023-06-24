using Account.Service.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Account.Service.Errors;

public class NotFoundError : ApplicationError
{
    public override int StatusCode => 404;

    public NotFoundError(string? message) : base(message)
    {
        
    }

    public NotFoundError(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}