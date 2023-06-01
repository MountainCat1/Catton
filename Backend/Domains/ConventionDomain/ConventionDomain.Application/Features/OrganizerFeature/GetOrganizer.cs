using ConventionDomain.Application.Dtos.Convention;
using ConventionDomain.Application.Dtos.Organizer;
using ConventionDomain.Application.Errors;
using ConventionDomain.Domain.Repositories;
using MediatR;

namespace ConventionDomain.Application.Features.OrganizerFeature;

public class GetOrganizerRequest : IRequest<OrganizerResponse>
{
    public Guid Id { get; set; }
}

public class GetOrganizerRequestHandler : IRequestHandler<GetOrganizerRequest, OrganizerResponse>
{
    private readonly IOrganizerRepository _repository;

    public GetOrganizerRequestHandler(IOrganizerRepository repository)
    {
        _repository = repository;
    }

    public async Task<OrganizerResponse> Handle(GetOrganizerRequest request, CancellationToken cancellationToken)
    {
        var id = request.Id;

        var entity = await _repository.GetOneAsync(id);

        if (entity is null)
            throw new NotFoundError();
        
        return entity.ToDto();
    }
}