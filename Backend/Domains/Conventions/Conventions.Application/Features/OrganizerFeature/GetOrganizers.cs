using Catut.Application.Errors;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Organizer;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.OrganizerFeature;

public class GetOrganizersRequest : IRequest<ICollection<OrganizerDto>>
{
    public required Guid ConventionId { get; set; }
}

public class GetOrganizersRequestHandler : IRequestHandler<GetOrganizersRequest, ICollection<OrganizerDto>>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public GetOrganizersRequestHandler(
        IOrganizerRepository organizerRepository,
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
        
        var authorizationResult = await _authorizationService.AuthorizeAsync(_userAccessor.User, convention, Policies.ReadConvention);
        authorizationResult.ThrowIfFailed();
        
        return convention.Organizers.Select(x => x.ToDto()).ToList();
    }
}