namespace ConventionDomain.Application.Dtos.Attendee;

public class AttendeeDto
{
    public Guid AccountId { get; set; }
    public string ConventionId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string AccountUsername { get; set; }
    public Uri? AccountAvatarUri { get; set; }
}

public static class AttendeeExtensions
{
    public static AttendeeDto ToDto(this Conventions.Domain.Entities.Attendee attendee)
    {
        return new AttendeeDto
        {
            AccountId = attendee.AccountId,
            CreatedDate = attendee.CreatedDate,
            AccountUsername = attendee.AccountUsername,
            AccountAvatarUri = attendee.AccountAvatarUri
        };
    }
}