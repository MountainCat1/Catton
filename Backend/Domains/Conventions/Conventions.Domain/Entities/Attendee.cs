using Catut.Domain.Abstractions;
using Catut.Domain.Errors;
using Conventions.Domain.Services;
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

    private readonly AttendeeValidator _validator;


    private Attendee()
    {
        _validator = new AttendeeValidator();
    }
    
    internal static Attendee CreateInstance(
        Guid accountId, 
        string accountUsername,
        Uri? accountProfilePicture = null)
    {
        var entity = new Attendee()
        {
            AccountId = accountId,
            CreatedDate = DateTime.UtcNow,
            AccountUsername = accountUsername,
            AccountAvatarUri = accountProfilePicture,
        };

        entity.ValidateAndThrow();

        return entity;
    }

    public async Task<Ticket> AddTicketAsync(TicketTemplate ticketTemplate, IPaymentDomainService paymentDomainService)
    {
        ticketTemplate.ValidateAndThrow();
        
        var paymentId = await paymentDomainService.CreatePaymentAsync(ticketTemplate.Price, ticketTemplate.Currency);
        
        var ticket = Ticket.CreateInstance(ticketTemplate, paymentId, this.Id);

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
        var result = _validator.Validate(this);
        
        if (result.IsValid)
            return;

        throw new ValidationDomainError("Validation failed", result.Errors);
    }
}