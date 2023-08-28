using Catut.Domain.Abstractions;
using Conventions.Domain.Validators;
using FluentValidation;

namespace Conventions.Domain.Entities;

public class Attendee : Entity
{
    public Guid AccountId { private set; get; }
    
    public DateTime CreatedDate { get; set; }
    
    public ICollection<Ticket> Tickets { get; set; }

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
            AccountAvatarUri = accountProfilePicture
        };

        entity.ValidateAndThrow();

        return entity;
    }

    public Ticket AddTicket(TicketTemplate ticketTemplate)
    {
        var ticket = Ticket.Create(ticketTemplate);
        
        Tickets.Add(ticket);

        return ticket;
    }
    
    public void ValidateAndThrow()
    {
        new AttendeeOrganizerValidator().ValidateAndThrow(this);
    }
}