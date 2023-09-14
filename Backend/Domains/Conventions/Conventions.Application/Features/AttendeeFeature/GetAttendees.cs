using Catut.Application.Errors;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Attendee;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.AttendeeFeature;

public class GetAttendeesRequest : IQuery<ICollection<AttendeeDto>>
{
    public required string ConventionId { get; init; }
}

public class GetAttendeesRequestHandler : IRequestHandler<GetAttendeesRequest, ICollection<AttendeeDto>>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public GetAttendeesRequestHandler(
        IConventionRepository conventionRepository,
        IUserAccessor userAccessor,
        IAuthorizationService authorizationService)
    {
        _conventionRepository = conventionRepository;
        _userAccessor = userAccessor;
        _authorizationService = authorizationService;
    }

    public async Task<ICollection<AttendeeDto>> Handle(GetAttendeesRequest req, CancellationToken ct)
    {
        var convention = await _conventionRepository.GetConvention(req.ConventionId);

        if (convention is null)
            throw new NotFoundError(
                $"Convention ({req.ConventionId}) was not found");

        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.ReadAttendee);

        var attendee = convention.Attendees;

        return attendee.Select(x => x.ToDto()).ToList();
    }
}