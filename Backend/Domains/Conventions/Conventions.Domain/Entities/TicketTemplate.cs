using System.ComponentModel.DataAnnotations.Schema;
using Catut.Domain.Abstractions;

namespace Conventions.Domain.Entities;

public class TicketTemplate : Entity
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool Avaliable { get; set; }

    public DateTime DateCreated { get; set; }

    public Guid ConventionId { get; set; }
    
    
    [ForeignKey(nameof(ConventionId))]
    public virtual Convention Convention { get; set; }


    public Guid? LastEditAuthorId { get; set; }
    public Guid AuthorId { get; set; }

    private TicketTemplate()
    {
    }
    
    public static TicketTemplate Create(string name, string description, decimal price, Guid conventionId, Guid authorId)
    {
        return new TicketTemplate()
        {
            Id = Guid.Empty, // sets to empty so that EF won't think its an existing entity
            Name = name,
            Description = description,
            Price = price,
            Avaliable = false,
            DateCreated = DateTime.UtcNow,
            ConventionId = conventionId,
            AuthorId = authorId
        };
    }
}