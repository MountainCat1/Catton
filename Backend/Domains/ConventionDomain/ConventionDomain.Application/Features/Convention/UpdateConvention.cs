using ConventionDomain.Application.Dtos;
using ConventionDomain.Domain.Entities;
using ConventionDomain.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace ConventionDomain.Application.Features.Convention;

public class UpdateConventionRequest : IRequest
{
    public required Guid Id { get; init; }
    public required ConventionUpdateDto UpdateDto { get; init; }
}

public class UpdateConventionRequestHandler : IRequestHandler<UpdateConventionRequest>
{
    private readonly IConventionRepository _conventionRepository;

    public UpdateConventionRequestHandler(IConventionRepository conventionRepository)
    {
        _conventionRepository = conventionRepository;
    }

    public async Task Handle(UpdateConventionRequest request, CancellationToken cancellationToken)
    {
        var entity = await _conventionRepository.GetOneRequiredAsync(request.Id);

        var updateDto = request.UpdateDto;

        var update = new ConventionUpdate()
        {
            Active = updateDto.Active,
            Description = updateDto.Description,
            Name = updateDto.Name
        };
        
        entity.Update(update);

        await _conventionRepository.SaveChangesAsync();
    }
}