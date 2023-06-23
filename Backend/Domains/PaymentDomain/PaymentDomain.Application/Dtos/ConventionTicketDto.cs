using PaymentDomain.Domain.Entities;

namespace PaymentDomain.Application.Dtos;

public class ConventionTicketDto
{
    public Guid Id { get; set; }

    public Guid ConventionId { get; set; }
    public Guid PaymentId { get; set; }

    public string Description { get; set; }

    public DateTime CreatedTime { get; set; }
}

public static class ConventionTicketExtensions
{
    public static ConventionTicketDto ToDto(this ConventionTicket ticket)
    {
        return new ConventionTicketDto()
        {
            Id = ticket.Id,
            Description = ticket.Description,
            CreatedTime = ticket.CreatedTime,
            ConventionId = ticket.ConventionId,
            PaymentId = ticket.ConventionId
        };
    }
}