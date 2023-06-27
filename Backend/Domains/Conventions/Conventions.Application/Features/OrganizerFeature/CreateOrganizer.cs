using Catut.Application.Errors;
using Conventions.Application.Dtos.Organizer;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using MediatR;

namespace Conventions.Application.Features.OrganizerFeature;

public class CreateOrganizerRequest : IRequest
{
    public required OrganizerCreateDto CreateDto { get; init; }
}

public class CreateOrganizerRequestHandler : IRequestHandler<CreateOrganizerRequest>
{
    private readonly IOrganizerRepository _organizerRepository;
    private readonly IConventionRepository _conventionRepository;

    public CreateOrganizerRequestHandler(
        IOrganizerRepository organizerRepository,
        IConventionRepository conventionRepository)
    {
        _organizerRepository = organizerRepository;
        _conventionRepository = conventionRepository;
    }

    public async Task Handle(CreateOrganizerRequest request, CancellationToken cancellationToken)
    {
        var dto = request.CreateDto;

        var convention = await _conventionRepository.GetOneAsync(dto.ConvnetionId);

        if (convention is null)
            throw new NotFoundError($"Convention with id {dto.ConvnetionId} not found");

        var entity = Organizer.CreateInstance(
            convention: convention,
            accountId: dto.AccountId,
            role: dto.Role
        );

        await _organizerRepository.AddAsync(entity);
        await _organizerRepository.SaveChangesAsync();
    }
}