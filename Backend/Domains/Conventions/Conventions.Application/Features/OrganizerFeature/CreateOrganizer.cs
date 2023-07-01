using Catut.Application.Errors;
using ConventionDomain.Application.Dtos.Organizer;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using MediatR;
using OpenApi.Accounts;

namespace ConventionDomain.Application.Features.OrganizerFeature;

public class CreateOrganizerRequest : IRequest
{
    public required OrganizerCreateDto CreateDto { get; init; }
}

public class CreateOrganizerRequestHandler : IRequestHandler<CreateOrganizerRequest>
{
    private readonly IOrganizerRepository _organizerRepository;
    private readonly IConventionRepository _conventionRepository;
    private readonly IAccountsApi _accountApi;

    public CreateOrganizerRequestHandler(
        IOrganizerRepository organizerRepository,
        IConventionRepository conventionRepository,
        IAccountsApi accountApi)
    {
        _organizerRepository = organizerRepository;
        _conventionRepository = conventionRepository;
        _accountApi = accountApi;
    }

    public async Task Handle(CreateOrganizerRequest request, CancellationToken ct)
    {
        var dto = request.CreateDto;

        var conventionTask = _conventionRepository.GetOneAsync(dto.ConventionId);
        var accountTask = _accountApi.AccountsGETAsync(dto.AccountId, ct);

        await Task.WhenAll(conventionTask, accountTask);

        var convention = conventionTask.Result ??
            throw new BadRequestError($"Convention with id {dto.ConventionId} not found");
        var account = accountTask.Result ??
            throw new BadRequestError($"Account with id {dto.AccountId} not found");

        var entity = Organizer.CreateInstance(
            convention: convention,
            accountId: account.Id,
            role: dto.Role
        );

        await _organizerRepository.AddAsync(entity);
        await _organizerRepository.SaveChangesAsync();
    }
}