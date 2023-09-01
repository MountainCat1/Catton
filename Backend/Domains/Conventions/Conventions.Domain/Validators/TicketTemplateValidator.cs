using Conventions.Domain.Entities;
using FluentValidation;

namespace Conventions.Domain.Validators;

public class TicketTemplateValidator : AbstractValidator<TicketTemplate>
{
    public TicketTemplateValidator()
    {
        RuleFor(x => x.Name).NotEmpty().Length(3, 64);
        RuleFor(x => x.Price).NotEmpty().GreaterThanOrEqualTo(0);
        
        RuleFor(x => x.LastUpdateDate).GreaterThanOrEqualTo(DateTime.UtcNow);
        RuleFor(x => x.CreatedDate).GreaterThanOrEqualTo(DateTime.UtcNow);
    }
}