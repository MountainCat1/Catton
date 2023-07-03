using Catut.Application.Errors;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Organizer;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.OrganizerFeature;

public class UpdateOrganizerRequest : IRequest<OrganizerDto>
{
    public required Guid OrganizerId { get; init; }
    public required Guid ConventionId { get; init; }
    public required OrganizerUpdateDto UpdateDto { get; init; }
}

public class UpdateOrganizerRequestHandler : IRequestHandler<UpdateOrganizerRequest, OrganizerDto>
{
    private readonly IOrganizerRepository _repository;
    private readonly IAuthorizationService _authService;
    private readonly IUserAccessor _userAccessor;

    public UpdateOrganizerRequestHandler(
        IOrganizerRepository repository,
        IAuthorizationService authService,
        IUserAccessor userAccessor)
    {
        _repository = repository;
        _authService = authService;
        _userAccessor = userAccessor;
    }

    public async Task<OrganizerDto> Handle(UpdateOrganizerRequest req, CancellationToken cancellationToken)
    {
        var organizer = await _repository.GetOneWithConventionAsync(req.ConventionId, req.OrganizerId);

        if (organizer is null)
            throw new NotFoundError(
                $"Organizer ({req.OrganizerId}) was not found for a convention ({req.ConventionId})");

        var authorizationResult = await _authService.AuthorizeAsync(_userAccessor.User, organizer.Convention, Policies.ReadConvention);
        authorizationResult.ThrowIfFailed();

        var update = new OrganizerUpdate()
        {
            Role = req.UpdateDto.Role
        };

        organizer.Update(update);

        await _repository.SaveChangesAsync();

        return organizer.ToDto();
    }
}