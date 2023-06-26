namespace TicketTemplateDomain.Application.Dtos;

public class TicketTemplateCreateDto
{
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
}