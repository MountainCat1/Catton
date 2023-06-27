using ConventionDomain.Application.Dtos.Convention;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using MediatR;

namespace ConventionDomain.Application.Features.ConventionFeature;

public class CreateConventionRequest : IRequest
{
    public required ConventionCreateDto ConventionCreateDto { get; init; }
}

public class CreateConventionRequestHandler : IRequestHandler<CreateConventionRequest>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IUserAccessor _userAccessor;

    public CreateConventionRequestHandler(IConventionRepository conventionRepository, IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _userAccessor = userAccessor;
    }

    public async Task Handle(CreateConventionRequest request, CancellationToken cancellationToken)
    {
        var dto = request.ConventionCreateDto;

        var entity = Convention.CreateInstance(dto.Name, dto.Description, _userAccessor.User.GetUserId());

        await _conventionRepository.AddAsync(entity);
        await _conventionRepository.SaveChangesAsync();
    }
}