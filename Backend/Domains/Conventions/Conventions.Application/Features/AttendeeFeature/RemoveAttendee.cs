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

public class RemoveAttendeeRequest : ICommand<AttendeeDto>
{
    public required string ConventionId { get; init; }
    public required Guid AccountId { get; init; }
}

public class RemoveAttendeeRequestHandler : IRequestHandler<RemoveAttendeeRequest, AttendeeDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public RemoveAttendeeRequestHandler(
        IConventionRepository conventionRepository,
        IUserAccessor userAccessor,
        IAuthorizationService authorizationService)
    {
        _conventionRepository = conventionRepository;
        _userAccessor = userAccessor;
        _authorizationService = authorizationService;
    }

    public async Task<AttendeeDto> Handle(RemoveAttendeeRequest req, CancellationToken ct)
    {
        var convention = await _conventionRepository.GetConvention(req.ConventionId);

        if (convention is null)
            throw new NotFoundError(
                $"Convention ({req.ConventionId}) was not found");
        
        var attendee = convention.Attendees.FirstOrDefault(x => x.AccountId == req.AccountId);

        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.RemoveAttendee);

        if (attendee is null)
            throw new NotFoundError(
                $"Attendee ({req.AccountId}) was not found for a convention ({req.ConventionId})");

        convention.RemoveAttendee(attendee);
        
        return attendee.ToDto();
    }
}