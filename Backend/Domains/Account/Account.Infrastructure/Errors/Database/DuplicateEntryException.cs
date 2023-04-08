using System.ComponentModel.DataAnnotations;

namespace Account.Infrastructure.Errors.Database;

public class DuplicateEntryException : ValidationException
{
    public DuplicateEntryException(string? message) : base(message)
    {
    }

    public DuplicateEntryException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}