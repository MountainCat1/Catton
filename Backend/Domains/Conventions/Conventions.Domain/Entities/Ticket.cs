using Catut.Domain.Abstractions;
using Catut.Domain.Errors;
using Conventions.Domain.Validators;

namespace Conventions.Domain.Entities;

public class Ticket : Entity
{
    public Guid Id { get; set; }

    public TicketTemplate TicketTemplate { get; set; }
    public Guid PaymentId { private set; get; }

    public DateTime CreatedDate { get; set; }

    private Ticket()
    {
    }

    internal static Ticket CreateInstance(TicketTemplate ticketTemplate, Guid paymentId)
    {
        var instance = new Ticket()
        {
            Id = Guid.NewGuid(),
            TicketTemplate = ticketTemplate,
            CreatedDate = DateTime.Now,
            PaymentId = paymentId
        };
        
        instance.ValidateAndThrow();

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