using ConventionDomain.Application.Dtos.Convention;
using ConventionDomain.Domain.Entities;
using ConventionDomain.Domain.Repositories;
using MediatR;

namespace ConventionDomain.Application.Features.ConventionFeature;

public class CreateConventionRequest : IRequest
{
    public required ConventionCreateDto ConventionCreateDto { get; init; }
}

public class CreateConventionRequestHandler : IRequestHandler<CreateConventionRequest>
{
    private readonly IConventionRepository _conventionRepository;

    public CreateConventionRequestHandler(IConventionRepository conventionRepository)
    {
        _conventionRepository = conventionRepository;
    }

    public async Task Handle(CreateConventionRequest request, CancellationToken cancellationToken)
    {
        var dto = request.ConventionCreateDto;

        var entity = Convention.CreateInstance(dto.Name, dto.Description);

        await _conventionRepository.AddAsync(entity);
        await _conventionRepository.SaveChangesAsync();
    }
}