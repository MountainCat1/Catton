﻿namespace BaseApp.Infrastructure.Abstractions;

public class DatabaseException : Exception
{
    public DatabaseException()
    {
    }

    public DatabaseException(string? message) : base(message)
    {
    }

    public DatabaseException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}