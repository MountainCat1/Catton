using Catut.Application.Errors;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Convention;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.ConventionFeature;

public class GetConventionRequest : IQuery<ConventionDto>
{
    public string Id { get; set; }
}

public class GetConventionRequestHandler : IRequestHandler<GetConventionRequest, ConventionDto>
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

    public async Task<ConventionDto> Handle(GetConventionRequest request, CancellationToken cancellationToken)
    {
        var id = request.Id;

        var convention = await _conventionRepository.GetConvention(request.Id);

        if (convention is null)
            throw new NotFoundError($"Convention with an id {id} does not exist");

        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.ReadConvention);

        return convention.ToDto();
    }
}