using Catut.Domain.Abstractions;
using Conventions.Domain.Validators;
using FluentValidation;

namespace Conventions.Domain.Entities;

public record TicketTemplateUpdate
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public bool? Avaliable { get; set; } 
}

public class TicketTemplate : Entity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; } 
    public bool Avaliable { get; set; }

    public DateTime CreateDate { get; set; }
    public DateTime LastUpdateDate { get; set; }

    public string ConventionId { get; set; }
    
    
    public virtual Convention Convention { get; set; } = null!;


    public Guid? LastEditAuthorId { get; set; }
    public Guid AuthorId { get; set; }

    private TicketTemplate()
    {

    }
    
    public static TicketTemplate Create(string name, string description, decimal price, string conventionId, Guid authorId)
    {
        var ticketTemplate = new TicketTemplate()
        {
            Id = Guid.Empty, // sets to empty so that EF won't think its an existing entity
            Name = name,
            Description = description,
            Price = price,
            Avaliable = false,
            
            CreateDate = DateTime.UtcNow,
            LastUpdateDate = DateTime.UtcNow,
            
            ConventionId = conventionId,
            AuthorId = authorId,
            LastEditAuthorId = authorId
        };
        
        ticketTemplate.ValidateAndThrow();

        return ticketTemplate;
    }

    public TicketTemplate Update(TicketTemplateUpdate update, Guid authorId)
    {
        Name = update.Name ?? Name;
        Description = update.Description ?? Description;
        Avaliable = update.Avaliable ?? Avaliable;
        Price = update.Price ?? Price;

        LastEditAuthorId = authorId;
        LastUpdateDate = DateTime.UtcNow;
        
        ValidateAndThrow();

        return this;
    }
    
    public void ValidateAndThrow()
    {
        new TicketTemplateValidator().ValidateAndThrow(this);
    }
}