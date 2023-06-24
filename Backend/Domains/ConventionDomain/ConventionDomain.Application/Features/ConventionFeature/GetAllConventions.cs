using System.Security.Claims;
using ConventionDomain.Application.Dtos.Convention;
using ConventionDomain.Application.Services;
using ConventionDomain.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.ConventionFeature;

public class GetAllConventionsRequest : IRequest<ICollection<ConventionResponse>>
{
    public Guid AccountId { get; set; }
}

public class GetAllConventionsRequestHandler : IRequestHandler<GetAllConventionsRequest, ICollection<ConventionResponse>>
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

    public async Task<ICollection<ConventionResponse>> Handle(GetAllConventionsRequest request, CancellationToken cancellationToken)
    {
        var accountId = request.AccountId;

        var entities = await _conventionRepository.GetByOrganizatorId(accountId);

        return entities.Select(x => x.ToDto()).ToList();
    }
}