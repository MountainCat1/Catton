using Catut.Application.Errors;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Organizer;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ConventionDomain.Application.Features.OrganizerFeature;

public class CreateOrganizerRequest : IRequest<OrganizerDto>
{
    public required OrganizerCreateDto OrganizerCreateDto { get; init; }
    public required Guid ConventionId { get; set; }
}

public class CreateOrganizerRequestHandler : IRequestHandler<CreateOrganizerRequest, OrganizerDto>
{
    private readonly IOrganizerRepository _organizerRepository;
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public CreateOrganizerRequestHandler(
        IOrganizerRepository organizerRepository,
        IConventionRepository conventionRepository,
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor)
    {
        _organizerRepository = organizerRepository;
        _conventionRepository = conventionRepository;
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
    }

    public async Task<OrganizerDto> Handle(CreateOrganizerRequest request, CancellationToken cancellationToken)
    {
        var dto = request.OrganizerCreateDto;

        var convention = await _conventionRepository.GetOneAsync(request.ConventionId);

        if (convention is null)
            throw new NotFoundError($"Convention with id {request.ConventionId} hasn't been found");

        var authorizationResult = await _authorizationService.AuthorizeAsync(_userAccessor.User, convention, Policies.CreateOrganizer);

        authorizationResult.ThrowIfFailed();
        
        var organizer = Organizer.CreateInstance(
            convention: convention,
            accountId: dto.AccountId,
            role: dto.Role
        );

        await _organizerRepository.AddAsync(entity: organizer);
        await _organizerRepository.SaveChangesAsync();

        return organizer.ToDto();
    }
}