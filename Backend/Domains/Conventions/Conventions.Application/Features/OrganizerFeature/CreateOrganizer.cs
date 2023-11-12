using Catut.Application.Errors;
using Catut.Domain.Errors;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Organizer;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using OpenApi.Accounts;

namespace ConventionDomain.Application.Features.OrganizerFeature;

public class CreateOrganizerRequest : ICommand<OrganizerDto>
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

    public async Task<OrganizerDto> Handle(CreateOrganizerRequest req, CancellationToken ct)
    {
        var dto = req.OrganizerCreateDto;

        var accountTask = _accountsApi.AccountsGETAsync(dto.AccountId, ct);
        
        var convention = await _conventionRepository.GetConvention(req.ConventionId);

        if (convention is null)
            throw new NotFoundError($"The convention ({req.ConventionId}) could not be found.");

        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.CreateOrganizer);

        var account = await accountTask;

        try
        {
            var organizer = convention.AddOrganizer(
                accountId: dto.AccountId, 
                accountUsername: account.Username,
                accountProfilePicture: null);
            
            await _conventionRepository.SaveChangesAsync();

            return organizer.ToDto();

        }
        catch (ConflictDomainError domainError)
        {
            throw new BadRequestError(domainError.Message);
        }
    }
}