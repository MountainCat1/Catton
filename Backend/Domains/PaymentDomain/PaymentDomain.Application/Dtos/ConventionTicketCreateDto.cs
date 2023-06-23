namespace PaymentDomain.Application.Dtos;

public class ConventionTicketCreateDto
{
    public Guid ConventionId { get; set; }

    public string Description { get; set; }
}