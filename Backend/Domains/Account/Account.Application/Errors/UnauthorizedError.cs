using Account.Service.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Account.Service.Errors;

public class UnauthorizedError : ApplicationError
{
    public override int StatusCode
    {
        get => 401;
    }
    public UnauthorizedError(string? message) : base(message)
    {
    }

    public UnauthorizedError(string? message, Exception? innerException) : base(message, innerException)
    {
    }
    
}