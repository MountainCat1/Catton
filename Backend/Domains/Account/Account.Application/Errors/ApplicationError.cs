﻿using Account.Service.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Account.Service.Errors;

public abstract class ApplicationError : Exception
{

    public ApplicationError(string? message) : base(message)
    {
    }

    public ApplicationError(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public abstract int StatusCode { get; }

    public virtual Error ToError()
    {
        return new Error()
        {
            Message = Message,
            StatusCode = StatusCode,
        };
    }

}
