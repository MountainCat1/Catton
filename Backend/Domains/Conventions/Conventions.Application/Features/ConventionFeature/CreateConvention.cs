using Catut.Application.Errors;
using Catut.Infrastructure.Errors.Database;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Dtos.Convention;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using MediatR;
using OpenApi.Accounts;

namespace ConventionDomain.Application.Features.ConventionFeature;

public class CreateConventionRequest : ICommand<ConventionDto>
{
    public required ConventionCreateDto ConventionCreateDto { get; init; }
}

public class CreateConventionRequestHandler : IRequestHandler<CreateConventionRequest, ConventionDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IUserAccessor _userAccessor;
    private readonly IAccountsApi _accountsApi;

    public CreateConventionRequestHandler(
        IConventionRepository conventionRepository,
        IUserAccessor userAccessor,
        IAccountsApi accountsApi)
    {
        _conventionRepository = conventionRepository;
        _userAccessor = userAccessor;
        _accountsApi = accountsApi;
    }

    public async Task<ConventionDto> Handle(CreateConventionRequest req, CancellationToken ct)
    {
        var dto = req.ConventionCreateDto;

        var accountId = _userAccessor.User.GetUserId();
        var account = await _accountsApi.AccountsGETAsync(accountId, ct);

        var convention = Convention.CreateInstance(dto.Id, dto.Name, dto.Description, accountId);
        convention.AddOrganizer(
            accountId: accountId, 
            accountUsername: account.Username, 
            accountProfilePicture: null);

        await _conventionRepository.AddAsync(convention);
        try
        {
            await _conventionRepository.SaveChangesAsync();
        }
        catch (DuplicateEntryException e)
        {
            throw new BadRequestError($"Convention with id ({req.ConventionCreateDto.Id}) already exists");
        }

        return convention.ToDto();
    }
}