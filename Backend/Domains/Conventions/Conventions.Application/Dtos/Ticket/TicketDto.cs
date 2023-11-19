namespace ConventionDomain.Application.Dtos.Ticket
{
    public class TicketDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string TicketTemplateName { get; set; }
        public Guid TicketTemplateId { get; set; }
    }

    public static class TicketExtensions
    {
        public static TicketDto ToDto(this Conventions.Domain.Entities.Ticket ticket)
        {
            return new TicketDto
            {
                Id = ticket.Id,
                CreatedDate = ticket.CreatedDate,
                
                TicketTemplateName = ticket.TicketTemplate.Name,
                TicketTemplateId = ticket.TicketTemplate.Id,
            };
        }
    }
}