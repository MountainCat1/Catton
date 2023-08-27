using Conventions.Domain.Validators;
using FluentValidation;

namespace Conventions.Domain.Entities;

public class Attendee
{
    public Guid AccountId { private set; get; }
    
    public Convention Convention { private set; get; }
    public string ConventionId { private set; get; }
    
    public DateTime CreatedDate { get; set; }
    
    // Data from account entity
    public string AccountUsername { get; set; }
    public Uri? AccountAvatarUri { get; set; }


    private Attendee()
    {
        
    }
    
    public static Attendee CreateInstance(
        Convention convention, 
        Guid accountId, 
        string accountUsername,
        Uri? accountProfilePicture = null,
        OrganizerRole? role = null)
    {
        var entity = new Attendee()
        {
            Convention = convention,
            ConventionId = convention.Id,
            AccountId = accountId,
            CreatedDate = DateTime.Now,
            AccountUsername = accountUsername,
            AccountAvatarUri = accountProfilePicture
        };

        entity.ValidateAndThrow();

        return entity;
    }
    
    public void ValidateAndThrow()
    {
        new AttendeeOrganizerValidator().ValidateAndThrow(this);
    }
}