using Catut.Domain.Abstractions;

namespace Catut.Domain.Errors;

public class ConflictDomainError : DomainError
{
    public ConflictDomainError()
    {
    }

    public ConflictDomainError(string? message) : base(message)
    {
    }

    public ConflictDomainError(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}