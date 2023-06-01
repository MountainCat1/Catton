using ConventionDomain.Application.Dtos.Convention;
using ConventionDomain.Application.Errors;
using ConventionDomain.Domain.Repositories;
using MediatR;

namespace ConventionDomain.Application.Features.ConventionFeature;

public class GetConventionRequest : IRequest<ConventionResponse>
{
    public Guid Id { get; set; }
}

public class GetConventionRequestHandler : IRequestHandler<GetConventionRequest, ConventionResponse>
{
    private readonly IConventionRepository _conventionRepository;

    public GetConventionRequestHandler(IConventionRepository conventionRepository)
    {
        _conventionRepository = conventionRepository;
    }

    public async Task<ConventionResponse> Handle(GetConventionRequest request, CancellationToken cancellationToken)
    {
        var id = request.Id;

        var entity = await _conventionRepository.GetOneAsync(id);

        if (entity is null)
            throw new NotFoundError();
        
        return entity.ToDto();
    }
}