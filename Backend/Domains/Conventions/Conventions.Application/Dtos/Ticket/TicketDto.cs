namespace ConventionDomain.Application.Dtos.Ticket
{
    public class TicketDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public static class TicketExtensions
    {
        public static TicketDto ToDto(this Conventions.Domain.Entities.Ticket ticket)
        {
            return new TicketDto
            {
                Id = ticket.Id,
                CreatedDate = ticket.CreatedDate,
            };
        }
    }
}