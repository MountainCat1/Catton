using ConventionDomain.Domain.Repositories;
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

        await _repository.DeleteAsync(id);
    }
}