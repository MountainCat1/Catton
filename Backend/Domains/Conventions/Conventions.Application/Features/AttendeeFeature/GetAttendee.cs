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

public class GetAttendeeRequest : IQuery<AttendeeDto>
{
    public required string ConventionId { get; init; }
    public required Guid AttendeeId { get; init; }
}

public class GetAttendeeRequestHandler : IRequestHandler<GetAttendeeRequest, AttendeeDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public GetAttendeeRequestHandler(
        IConventionRepository conventionRepository,
        IUserAccessor userAccessor,
        IAuthorizationService authorizationService)
    {
        _conventionRepository = conventionRepository;
        _userAccessor = userAccessor;
        _authorizationService = authorizationService;
    }

    public async Task<AttendeeDto> Handle(GetAttendeeRequest req, CancellationToken ct)
    {
        var convention =
            await _conventionRepository.GetOneWithAsync(req.ConventionId, x => req.AttendeeId, x => x.Attendees);

        if (convention is null)
            throw new NotFoundError(
                $"Convention ({req.ConventionId}) was not found");
        
        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.ReadAttendee);

        var attendee = convention.Attendees.FirstOrDefault(x => x.AccountId == req.AttendeeId);
        
        if (attendee is null)
            throw new NotFoundError(
                $"Attendee ({req.AttendeeId}) was not found for a convention ({req.ConventionId})");

        return attendee.ToDto();
    }
}