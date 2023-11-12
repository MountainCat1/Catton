using Catut.Domain.Abstractions;
using Catut.Domain.Errors;
using Conventions.Domain.Validators;

namespace Conventions.Domain.Entities;

public class Attendee : Entity
{
    public Guid Id { get; set; }
    
    public Guid AccountId { private set; get; }
    
    public DateTime CreatedDate { get; set; }

    private readonly List<Ticket> _tickets = new();
    public IReadOnlyCollection<Ticket> Tickets => _tickets;


    // Data from account entity
    public string AccountUsername { get; set; }
    public Uri? AccountAvatarUri { get; set; }


    private Attendee()
    {
    }
    
    internal static Attendee CreateInstance(
        Guid accountId, 
        string accountUsername,
        Uri? accountProfilePicture = null)
    {
        var entity = new Attendee()
        {
            AccountId = accountId,
            CreatedDate = DateTime.Now,
            AccountUsername = accountUsername,
            AccountAvatarUri = accountProfilePicture,
        };

        entity.ValidateAndThrow();

        return entity;
    }

    public Ticket AddTicket(TicketTemplate ticketTemplate)
    {
        var ticket = Ticket.CreateInstance(ticketTemplate);
            
        _tickets.Add(ticket);

        return ticket;
    }
    
    public Ticket RemoveTicket(Ticket ticket)
    {
        _tickets.Remove(ticket);

        return ticket;
    }
    
    public void ValidateAndThrow()
    {
        var result = new AttendeeValidator().Validate(this);
        
        if (result.IsValid)
            return;

        throw new ValidationDomainError("Validation failed", result.Errors);
    }
}