using Account.Service.Errors;
using ConventionDomain.Domain.Repositories;
using ConventionDomain.Infrastructure.Generics;
using MediatR;

namespace ConventionDomain.Application.Features.CreateConvention;

public class GetConventionRequest : IRequest
{
    public Guid Id { get; set; }
}

public class GetConventionRequestHandler : IRequestHandler<GetConventionRequest>
{
    private readonly IConventionRepository _conventionRepository;

    public GetConventionRequestHandler(IConventionRepository conventionRepository)
    {
        _conventionRepository = conventionRepository;
    }

    public async Task Handle(GetConventionRequest request, CancellationToken cancellationToken)
    {
        var id = request.Id;

        var entity = await _conventionRepository.GetOneAsync(id);

        if (entity is null)
            throw new NotFoundError();
        
        // TODO: make it map to dto
        
        return entity;
    }
}