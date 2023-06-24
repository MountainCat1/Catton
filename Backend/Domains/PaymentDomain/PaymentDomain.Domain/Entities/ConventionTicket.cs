using Catut.Domain.Abstractions;
using FluentValidation;
using PaymentDomain.Domain.Validators;

namespace PaymentDomain.Domain.Entities;

public class ConventionTicket : Entity
{
    private ConventionTicket(string description, Guid conventionId)
    {
        ConventionId = conventionId;
        Description = description;
    }

    public static async Task<ConventionTicket> CreateAsync(string description, Guid conventionId)
    {
        var newEntity = new ConventionTicket(description, conventionId);

        var validator = new ConventionTicketValidator();

        await validator.ValidateAndThrowAsync(newEntity);
        
        return newEntity;
    }
    
    public Guid Id { get; set; }

    public string Description { get; set; }
    
    public Guid ConventionId { get; set; }
    public Guid PaymentId { get; set; }
    

    public DateTime CreatedTime { get; set; }


}