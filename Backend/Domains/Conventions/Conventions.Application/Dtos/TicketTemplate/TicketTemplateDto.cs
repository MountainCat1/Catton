namespace ConventionDomain.Application.Dtos.TicketTemplate;

public class TicketTemplateDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool Available { get; set; }

    public DateTime CreateDate { get; set; }

    public string ConventionId { get; set; } = "";

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
            Available = ticketTemplate.Avaliable,
            CreateDate = ticketTemplate.CreatedDate,
            LastEditAuthorId = ticketTemplate.LastEditAuthorId,
            AuthorId = ticketTemplate.AuthorId
        };
    }
}
