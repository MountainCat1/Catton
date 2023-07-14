using System.ComponentModel.DataAnnotations.Schema;
using Catut.Domain.Abstractions;
using Conventions.Domain.Validators;
using FluentValidation;

namespace Conventions.Domain.Entities;

public enum OrganizerRole
{
    Guest, Owner, Administrator, Moderator, Announcer, Helper
}

public record OrganizerUpdate
{
    public virtual OrganizerRole Role { get; set; }
}

public class Organizer : Entity
{
    public static OrganizerRole DefaultRole
    {
        get => OrganizerRole.Helper;
    }
    
    public Guid AccountId { private set; get; }
    
    [ForeignKey(nameof(ConventionId))]
    public Convention Convention { private set; get; }
    public Guid ConventionId { private set; get; }
    
    
    public DateTime CreatedDate { get; set; }
    
    public virtual OrganizerRole Role { get; set; }

    private Organizer()
    {
    }
    
    public static Organizer CreateInstance(Convention convention, Guid accountId, OrganizerRole? role = null)
    {
        var entity = new Organizer()
        {
            Convention = convention,
            ConventionId = convention.Id,
            AccountId = accountId,
            CreatedDate = DateTime.Now,
            Role = role ?? DefaultRole
        };

        entity.ValidateAndThrow();

        return entity;
    }

    public void ValidateAndThrow()
    {
        new ConventionOrganizerValidator().ValidateAndThrow(this);
    }

    public void Update(OrganizerUpdate update)
    {
        Role = update.Role;
        
        ValidateAndThrow();
    }
}