using Catut.Domain.Abstractions;
using FluentValidation.Results;

namespace Catut.Domain.Errors;

public class ValidationDomainError : DomainError
{
    public IEnumerable<ValidationFailure> Errors { get; set; }

    public ValidationDomainError(IEnumerable<ValidationFailure> errors)
    {
        Errors = errors;
    }

    public ValidationDomainError(string? message, IEnumerable<ValidationFailure> errors) : base(message)
    {
        Errors = errors;
    }

    public ValidationDomainError(
        string? message,
        Exception? innerException,
        IEnumerable<ValidationFailure> errors) : base(message, innerException)
    {
        Errors = errors;
    }
}