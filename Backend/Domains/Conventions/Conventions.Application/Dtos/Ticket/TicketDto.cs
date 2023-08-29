namespace ConventionDomain.Application.Dtos.Ticket;

public class TicketDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid AtendeeId { get; set; }
    public Guid PaymentId { get; set; }
    public Guid TicketTemplateId { get; set; }
    public string ConventionId { get; set; } = null!;
}
public static class TicketExtensions
{
    public static TicketDto ToDto(this Conventions.Domain.Entities.Ticket ticket)
    {
        return new TicketDto
        {
            Id = ticket.Id,
            CreatedDate = ticket.CreatedDate,
            AtendeeId = ticket.AtendeeId,
            PaymentId = ticket.PaymentId,
        };
    }
}
