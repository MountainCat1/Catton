using ConventionDomain.Application.Dtos.Organizer;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using MediatR;

namespace ConventionDomain.Application.Features.OrganizerFeature;

public class UpdateOrganizerRequest : IRequest
{
    public required Guid Id { get; init; }
    public required OrganizerUpdateDto UpdateDto { get; init; }
}

public class UpdateOrganizerRequestHandler : IRequestHandler<UpdateOrganizerRequest>
{
    private readonly IOrganizerRepository _repository;

    public UpdateOrganizerRequestHandler(IOrganizerRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateOrganizerRequest request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetOneRequiredAsync(request.Id);

        var updateDto = request.UpdateDto;

        var update = new OrganizerUpdate()
        {
            Role = updateDto.Role
        };
        
        entity.Update(update);

        await _repository.SaveChangesAsync();
    }
}