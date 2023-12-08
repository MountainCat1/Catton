using Catut.Application.Abstractions;
using Catut.Application.Errors;
using Catut.Application.Services;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Attendee;
using ConventionDomain.Application.Extensions;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.AttendeeFeature;

public class GetAttendeeRequest : IQuery<AttendeeDto>
{
    public required string ConventionId { get; init; }
    public required Guid AccountId { get; init; }
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
        var convention = await _conventionRepository.GetConvention(req.ConventionId);

        if (convention is null)
            throw new NotFoundError(
                $"Convention ({req.ConventionId}) was not found");

        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.ReadAttendee);

        var attendee = convention.Attendees.FirstOrDefault(x => x.AccountId == req.AccountId);

        if (attendee is null)
            throw new NotFoundError(
                $"Attendee ({req.AccountId}) was not found for a convention ({req.ConventionId})");

        return attendee.ToDto();
    }
}