using Catut.Domain.Abstractions;
using Catut.Domain.Errors;
using Conventions.Domain.Validators;

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
    public string Currency { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdateDate { get; set; }

    public Guid? LastEditAuthorId { get; set; }
    public Guid AuthorId { get; set; }

    private TicketTemplate()
    {

    }
    
    internal static TicketTemplate Create(string name, string description, decimal price, Guid authorId)
    {
        var ticketTemplate = new TicketTemplate()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Price = price,
            Avaliable = false,
            Currency = "pln", // TODO: Make it a variable somehow
            
            CreatedDate = DateTime.UtcNow,
            LastUpdateDate = DateTime.UtcNow,
            
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
        var result = new TicketTemplateValidator().Validate(this);

        if (result.IsValid)
            return;

        throw new ValidationDomainError("Validation failed", result.Errors);
    }
}