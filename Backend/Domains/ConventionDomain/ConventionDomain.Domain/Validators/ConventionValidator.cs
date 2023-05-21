using ConventionDomain.Domain.Entities;
using FluentValidation;

namespace ConventionDomain.Domain.Validators;

public class ConventionValidator : AbstractValidator<Convention>
{
    public ConventionValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.Description).NotNull();
    }
}