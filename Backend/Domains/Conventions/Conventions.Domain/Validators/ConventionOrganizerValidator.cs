using Conventions.Domain.Entities;
using FluentValidation;

namespace Conventions.Domain.Validators;

public class ConventionOrganizerValidator : AbstractValidator<Organizer>
{
    public ConventionOrganizerValidator()
    {
    }
}