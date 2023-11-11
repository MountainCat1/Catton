namespace Catut.Infrastructure.Exception;

public class DatabaseException : System.Exception
{
    public DatabaseException()
    {
    }

    public DatabaseException(string? message) : base(message)
    {
    }

    public DatabaseException(string? message, System.Exception? innerException) : base(message, innerException)
    {
    }
}