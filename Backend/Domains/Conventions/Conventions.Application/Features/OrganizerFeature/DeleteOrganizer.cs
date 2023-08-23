using Catut.Application.Errors;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Organizer;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.OrganizerFeature;

public class DeleteOrganizerRequest : IRequest<OrganizerDto>
{
    public required string ConventionId { get; init; }
    public required Guid OrganizerId { get; init; }
}

public class DeleteOrganizerRequestHandler : IRequestHandler<DeleteOrganizerRequest, OrganizerDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public DeleteOrganizerRequestHandler(
        IConventionRepository conventionRepository,
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
    }

    public async Task<OrganizerDto> Handle(DeleteOrganizerRequest req, CancellationToken cancellationToken)
    {
        var convention = await _conventionRepository.GetOneWithOrganizersAsync(req.ConventionId);

        if (convention is null)
            throw new NotFoundError($"The convention ({req.ConventionId}) could not be found.");
        
        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.DeleteOrganizer);
        
        var organizer = convention.RemoveOrganizer(req.OrganizerId);

        if(organizer is null)
            throw new NotFoundError($"The organizer ({req.OrganizerId}) could not be found.");
        
        return organizer.ToDto();
    }
}