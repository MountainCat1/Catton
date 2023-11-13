using Catut.Domain.Abstractions;
using Catut.Domain.Errors;
using Conventions.Domain.Validators;

namespace Conventions.Domain.Entities;

public class Ticket : Entity
{
    public Guid Id { get; set; }

    public TicketTemplate TicketTemplate { get; set; }

    public DateTime CreatedDate { get; set; }

    private Ticket()
    {
    }

    internal static Ticket CreateInstance(TicketTemplate ticketTemplate)
    {
        var instance = new Ticket()
        {
            Id = Guid.NewGuid(),
            TicketTemplate = ticketTemplate,
            CreatedDate = DateTime.Now,
        };

        return instance;
    }

    public void Update()
    {
        // There is nothing to update for now so this method does nothing for now, it's more like a placeholder
        
        ValidateAndThrow();
    }

    public void ValidateAndThrow()
    {
        var result = new TicketValidator().Validate(this);
        
        if (result.IsValid)
            return;

        throw new ValidationDomainError("Validation failed", result.Errors);
    }
}