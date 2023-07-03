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
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public CreateOrganizerRequestHandler(
        IConventionRepository conventionRepository,
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
    }

    public async Task<OrganizerDto> Handle(CreateOrganizerRequest request, CancellationToken cancellationToken)
    {
        var dto = request.OrganizerCreateDto;

        var convention = await _conventionRepository.GetOneWithOrganizersAsync(request.ConventionId);

        if (convention is null)
            throw new NotFoundError($"The convention ({request.ConventionId}) could not be found.");

        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.CreateOrganizer);

        var organizer = Organizer.CreateInstance(
            convention: convention,
            accountId: dto.AccountId,
            role: dto.Role
        );

        convention.AddOrganizer(organizer);
        await _conventionRepository.SaveChangesAsync();

        return organizer.ToDto();
    }
}