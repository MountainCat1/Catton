using System.ComponentModel.DataAnnotations.Schema;
using ConventionDomain.Domain.Abstractions;
using ConventionDomain.Domain.Validators;
using FluentValidation;

namespace ConventionDomain.Domain.Entities;

public enum OrganiserRole
{
    Owner, Administrator, Moderator, Announcer
}

public class ConventionOrganizer : Entity
{
    public Guid Id { get; private set; }
    
    public Guid AccountId { private set; get; }
    
    [ForeignKey(nameof(ConventionId))]
    public Convention Convention { private set; get; }
    public Guid ConventionId { private set; get; }
    
    
    public DateTime CreatedDate { get; set; }
    
    public virtual ICollection<OrganiserRole> Roles { get; set; }

    private ConventionOrganizer()
    {
        
    }
    
    public static ConventionOrganizer CreateInstance(Convention convention, Guid accountId)
    {
        var entity = new ConventionOrganizer()
        {
            Convention = convention,
            ConventionId = convention.Id,
            AccountId = accountId,
            CreatedDate = DateTime.Now
        };

        entity.ValidateAndThrow();

        return entity;
    }
    
    public void ValidateAndThrow()
    {
        new ConventionOrganizerValidator().ValidateAndThrow(this);
    }
}