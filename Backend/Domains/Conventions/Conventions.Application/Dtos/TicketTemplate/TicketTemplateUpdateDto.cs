namespace ConventionDomain.Application.Dtos.TicketTemplate;

public class TicketTemplateUpdateDto
{
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? Name { get; set; }
    public bool? Avaliable { get; set; }
}