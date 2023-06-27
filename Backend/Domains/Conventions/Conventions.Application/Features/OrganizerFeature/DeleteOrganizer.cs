using Catut.Application.Errors;
using Conventions.Domain.Repositories;
using MediatR;

namespace ConventionDomain.Application.Features.OrganizerFeature;

public class DeleteOrganizerRequest : IRequest
{
    public Guid Id { get; set; }
}

public class DeleteOrganizerRequestHandler : IRequestHandler<DeleteOrganizerRequest>
{
    private readonly IOrganizerRepository _repository;

    public DeleteOrganizerRequestHandler(IOrganizerRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteOrganizerRequest request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        
        var entity = await _repository.GetOneAsync(id);

        if (entity is null)
            throw new NotFoundError($"Organizer with an id {id} does not exist");

        await _repository.DeleteAsync(entity);
    }
}