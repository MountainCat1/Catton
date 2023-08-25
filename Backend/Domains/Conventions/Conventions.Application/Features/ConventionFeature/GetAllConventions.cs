using System.Security.Claims;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Dtos.Convention;
using ConventionDomain.Application.Services;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.ConventionFeature;

public class GetAllConventionsRequest : IQuery<ICollection<ConventionDto>>
{
    public Guid AccountId { get; set; }
}

public class GetAllConventionsRequestHandler : IRequestHandler<GetAllConventionsRequest, ICollection<ConventionDto>>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly ClaimsPrincipal _user;

    public GetAllConventionsRequestHandler(
        IConventionRepository conventionRepository,
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _authorizationService = authorizationService;
        _user = userAccessor.User;
    }

    public async Task<ICollection<ConventionDto>> Handle(GetAllConventionsRequest request, CancellationToken cancellationToken)
    {
        var accountId = request.AccountId;

        var entities = await _conventionRepository.GetByOrganizatorId(accountId);

        return entities.Select(x => x.ToDto()).ToList();
    }
}