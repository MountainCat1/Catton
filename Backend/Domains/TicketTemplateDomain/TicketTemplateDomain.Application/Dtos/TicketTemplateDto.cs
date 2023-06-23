using TicketTemplateDomain.Domain.Entities;

namespace TicketTemplateDomain.Application.Dtos;

public class TicketTemplateDto
{
    public Guid Id { get; set; }

    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    
    public Guid ConventionId { get; set; }
}


public static class TicketTemplateExtensions
{
    public static TicketTemplateDto ToDto(this TicketTemplate entity)
    {
        return new TicketTemplateDto()
        {
            Id = entity.Id,
            
            Price = entity.Price,
            Description = entity.Description,
            ConventionId = entity.ConventionId,
        };
    }
}