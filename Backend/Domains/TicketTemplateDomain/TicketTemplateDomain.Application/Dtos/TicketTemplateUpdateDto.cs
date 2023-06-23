namespace TicketTemplateDomain.Application.Dtos;

public class TicketTemplateUpdateDto
{
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
}