using ConventionDomain.Domain.Abstractions;
using ConventionDomain.Domain.Events;
using ConventionDomain.Domain.Validators;
using FluentValidation;

namespace ConventionDomain.Domain.Entities;

public record ConventionUpdate
{
    public string? Name { get; init; }
    public string? Description { get; init; }  
    public bool? Active { get; init; }  
}

public class Convention : Entity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public DateTime CreatedDate { private set; get; }
    public bool Active { get; private set; }
    
    public virtual ICollection<Organizer> Organizers { get; set; }


    private Convention()
    {
    }

    public static Convention CreateInstance(string name, string description, Guid creatorId)
    {
        var entity = new Convention
        {
            Name = name,
            Description = description,
            CreatedDate = DateTime.Now
        };

        entity.ValidateAndThrow();
        
        entity.AddDomainEvent(new ConventionCreatedDomainEvent()
        {
            AccountId = creatorId
        });

        return entity;
    }

    public void Update(ConventionUpdate update)
    {
        Name = update.Name ?? Name;
        Description = update.Description ?? Description;
        Active = update.Active ?? Active;
        
        ValidateAndThrow();
    }
    
    public void ValidateAndThrow()
    {
        new ConventionValidator().ValidateAndThrow(this);
    }
}

