namespace ConventionDomain.Application.Dtos.TicketTemplate;

public class TicketTemplateDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool Avaliable { get; set; }

    public DateTime DateCreated { get; set; }

    public Guid ConvetionId { get; set; }

    public Guid? LastEditAuthorId { get; set; }
    public Guid AuthorId { get; set; }
}


public static class TicketTemplateExtensions
{
    public static TicketTemplateDto ToDto(this Conventions.Domain.Entities.TicketTemplate ticketTemplate)
    {
        return new TicketTemplateDto
        {
            Id = ticketTemplate.Id,
            Name = ticketTemplate.Name,
            Description = ticketTemplate.Description,
            Price = ticketTemplate.Price,
            Avaliable = ticketTemplate.Avaliable,
            DateCreated = ticketTemplate.DateCreated,
            ConvetionId = ticketTemplate.ConventionId,
            LastEditAuthorId = ticketTemplate.LastEditAuthorId,
            AuthorId = ticketTemplate.AuthorId
        };
    }
}
