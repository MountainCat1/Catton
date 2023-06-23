using FluentValidation;
using PaymentDomain.Domain.Entities;

namespace PaymentDomain.Domain.Validators;

public class ConventionTicketValidator : AbstractValidator<ConventionTicket>
{
    public ConventionTicketValidator()
    {
        
    }
}