using Catut.Application.Errors;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Organizer;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.OrganizerFeature;

public class UpdateOrganizerRequest : IRequest<OrganizerDto>
{
    public required Guid OrganizerId { get; init; }
    public required Guid ConventionId { get; init; }
    public required OrganizerUpdateDto UpdateDto { get; init; }
}

public class UpdateOrganizerRequestHandler : IRequestHandler<UpdateOrganizerRequest, OrganizerDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authService;
    private readonly IUserAccessor _userAccessor;

    public UpdateOrganizerRequestHandler(
        IConventionRepository conventionRepository,
        IAuthorizationService authService,
        IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _authService = authService;
        _userAccessor = userAccessor;
    }

    public async Task<OrganizerDto> Handle(UpdateOrganizerRequest req, CancellationToken cancellationToken)
    {
        var (convention, organizer) = await _conventionRepository.GetOrganizerAsync(req.ConventionId, req.OrganizerId);

        await _authService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.UpdateOrganizer);
        
        if (organizer is null)
            throw new NotFoundError(
                $"Organizer ({req.OrganizerId}) was not found for a convention ({req.ConventionId})");
        
        var update = new OrganizerUpdate()
        {
            Role = req.UpdateDto.Role
        };

        organizer.Update(update);

        await _conventionRepository.SaveChangesAsync();

        return organizer.ToDto();
    }
}