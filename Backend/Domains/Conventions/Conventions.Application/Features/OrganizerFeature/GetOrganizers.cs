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

public class GetOrganizersRequest : IQuery<ICollection<OrganizerDto>>
{
    public required string ConventionId { get; set; }
}

public class GetOrganizersRequestHandler : IRequestHandler<GetOrganizersRequest, ICollection<OrganizerDto>>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public GetOrganizersRequestHandler(
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor,
        IConventionRepository conventionRepository)
    {
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
        _conventionRepository = conventionRepository;
    }

    public async Task<ICollection<OrganizerDto>> Handle(GetOrganizersRequest req, CancellationToken cancellationToken)
    {
        var convention = await _conventionRepository.GetOneWithOrganizersAsync(req.ConventionId);
        
        if (convention is null)
            throw new NotFoundError($"Organizer with an id {req.ConventionId} does not exist");
        
        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.ReadOrganizer);
        
        return convention.Organizers.Select(x => x.ToDto()).ToList();
    }
}