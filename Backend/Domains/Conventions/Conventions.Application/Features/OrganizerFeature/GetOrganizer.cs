using Catut.Application.Errors;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Organizer;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.OrganizerFeature;

public class GetOrganizerRequest : IQuery<OrganizerDto>
{
    public required string ConventionId { get; set; }
    public required Guid OrganizerId { get; set; }
}

public class GetOrganizerRequestHandler : IRequestHandler<GetOrganizerRequest, OrganizerDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public GetOrganizerRequestHandler(
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor,
        IConventionRepository conventionRepository)
    {
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
        _conventionRepository = conventionRepository;
    }

    public async Task<OrganizerDto> Handle(GetOrganizerRequest req, CancellationToken cancellationToken)
    {
        var convention = await _conventionRepository.GetConvention(req.ConventionId);

        var organizer = convention?.Organizers.FirstOrDefault(x => x.AccountId == req.OrganizerId);

        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.ReadOrganizer);

        if (organizer is null)
            throw new NotFoundError(
                $"Organizer ({req.OrganizerId}) was not found for a convention ({req.ConventionId})");

        return organizer.ToDto();
    }
}