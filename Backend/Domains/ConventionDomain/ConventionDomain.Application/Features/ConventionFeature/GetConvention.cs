using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Convention;
using ConventionDomain.Application.Errors;
using ConventionDomain.Application.Services;
using ConventionDomain.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace ConventionDomain.Application.Features.ConventionFeature;

public class GetConventionRequest : IRequest<ConventionResponse>
{
    public Guid Id { get; set; }
}

public class GetConventionRequestHandler : IRequestHandler<GetConventionRequest, ConventionResponse>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public GetConventionRequestHandler(
        IConventionRepository conventionRepository,
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
    }

    public async Task<ConventionResponse> Handle(GetConventionRequest request, CancellationToken cancellationToken)
    {
        var id = request.Id;

        var entity = await _conventionRepository.GetOneAsync(id);

        if (entity is null)
            throw new NotFoundError();

        var authorizationResult = await _authorizationService.AuthorizeAsync(_userAccessor.User, entity, Operations.Read);

        if (!authorizationResult.Succeeded)
            throw new UnauthorizedError();

        return entity.ToDto();
    }
}