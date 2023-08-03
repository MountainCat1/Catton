using Catut.Application.Errors;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Organizer;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using OpenApi.Accounts;

namespace ConventionDomain.Application.Features.OrganizerFeature;

public class CreateOrganizerRequest : IRequest<OrganizerDto>
{
    public required OrganizerCreateDto OrganizerCreateDto { get; init; }
    public required string ConventionId { get; set; }
}

public class CreateOrganizerRequestHandler : IRequestHandler<CreateOrganizerRequest, OrganizerDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;
    private readonly IAccountsApi _accountsApi;

    public CreateOrganizerRequestHandler(
        IConventionRepository conventionRepository,
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor,
        IAccountsApi accountsApi)
    {
        _conventionRepository = conventionRepository;
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
        _accountsApi = accountsApi;
    }

    public async Task<OrganizerDto> Handle(CreateOrganizerRequest req, CancellationToken cancellationToken)
    {
        var dto = req.OrganizerCreateDto;

        await _accountsApi.AccountsGETAsync(dto.AccountId, cancellationToken);
        
        var convention = await _conventionRepository.GetOneWithAsync(req.ConventionId, c => c.Organizers);

        if (convention is null)
            throw new NotFoundError($"The convention ({req.ConventionId}) could not be found.");

        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.CreateOrganizer);

        if (convention.Organizers.Any(x => x.AccountId == dto.AccountId))
            throw new BadRequestError(
                $"Account ({dto.AccountId}) is already an organizer of the convention ({req.ConventionId})");

        var organizer = Organizer.CreateInstance(
            convention: convention,
            accountId: dto.AccountId,
            role: dto.Role
        );

        convention.AddOrganizer(organizer);
        await _conventionRepository.SaveChangesAsync();

        return organizer.ToDto();
    }
}