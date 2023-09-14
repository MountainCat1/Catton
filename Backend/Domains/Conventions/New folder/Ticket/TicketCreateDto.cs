namespace ConventionDomain.Application.Dtos.Ticket;

public class TicketCreateDto
{
    public Guid AtendeeId { get; set; }
    public Guid PaymentId { get; set; }
    public Guid TicketTemplateId { get; set; }
    public string ConventionId { get; set; }
}


