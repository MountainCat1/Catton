using ConventionDomain.Application.Dtos;
using ConventionDomain.Domain.Entities;
using ConventionDomain.Domain.Repositories;
using MediatR;

namespace ConventionDomain.Application.Features.CreateConvention;

public class CreateConventionRequest : IRequest
{
    public required CreateConventionDto CreateDto { get; init; }
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
        var dto = request.CreateDto;

        var entity = Convention.CreateInstance(dto.Name, dto.Description);

        await _conventionRepository.AddAsync(entity);
        await _conventionRepository.SaveChangesAsync();
    }
}