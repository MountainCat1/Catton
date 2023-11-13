using Conventions.Domain.Entities;
using FluentValidation;

namespace Conventions.Domain.Validators;

public class TicketValidator: AbstractValidator<Ticket>
{
    public TicketValidator()
    {
        RuleFor(x => x.TicketTemplate).NotNull();
    }
}