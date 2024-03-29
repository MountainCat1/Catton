﻿using Conventions.Domain.Entities;

namespace ConventionDomain.Application.Dtos.Organizer;

public record OrganizerDto
{
    public Guid AccountId { get; init; }
    public string ConventionId { get; init; }
    public DateTime CreatedDate { get; init; }
    public OrganizerRole Role { get; init; }
    public string AccountUsername { get; set; }
    public Uri? AccountAvatarUri { get; set; }
}

public static class ConventionOrganizerExtensions
{
    public static OrganizerDto ToDto(this Conventions.Domain.Entities.Organizer organizer)
    {
        return new OrganizerDto
        {
            AccountId = organizer.AccountId,
            CreatedDate = organizer.CreatedDate,
            ConventionId = organizer.ConventionId,
            
            Role = organizer.Role,
            
            AccountUsername = organizer.AccountUsername,
            AccountAvatarUri = organizer.AccountAvatarUri
        };
    }
}