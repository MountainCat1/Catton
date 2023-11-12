using Catut.Infrastructure.Exception;

namespace Catut.Infrastructure.Errors.Database;

public class DuplicateEntryException : DatabaseException
{
    public DuplicateEntryException(string message) : base(message)
    {
    }

    public DuplicateEntryException()
    {
    }
    

    public DuplicateEntryException(string? message, System.Exception? innerException) : base(message, innerException)
    {
    }
}