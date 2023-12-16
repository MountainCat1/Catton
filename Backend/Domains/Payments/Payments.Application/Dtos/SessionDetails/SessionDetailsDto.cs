namespace Payments.Application.Dtos.SessionDetails;

public class SessionDetailsDto
{
    public string Id { get; set; }
    public string Url { get; set; }
    public DateTime ExpiresAt { get; set; }
}

public static class SesstionDetailsDtoExtensions
{
    public static SessionDetailsDto ToDto(this Domain.ValueObjects.SessionDetails sessionDetails)
    {
        return new SessionDetailsDto
        {
            Id = sessionDetails.Id,
            Url = sessionDetails.Url,
            ExpiresAt = sessionDetails.ExpiresAt
        };
    }
}