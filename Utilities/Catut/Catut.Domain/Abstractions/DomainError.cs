namespace Catut.Domain.Abstractions;

public interface IDomainError
{
}

public class DomainError : Exception, IDomainError
{
    public DomainError()
    {
    }

    public DomainError(string? message) : base(message)
    {
    }

    public DomainError(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}