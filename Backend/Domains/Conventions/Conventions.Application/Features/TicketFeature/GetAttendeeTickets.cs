using Catut.Application.Abstractions;
using Catut.Application.Errors;
using Catut.Application.Services;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Ticket;
using ConventionDomain.Application.Extensions;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.TicketFeature;

public class GetAttendeeTicketsRequest : IQuery<ICollection<TicketDto>>
{
    public required string ConventionId { get; init; }
    public required Guid AtendeeId { get; init; }
}

public class GetAttendeeTicketsHandler : IRequestHandler<GetAttendeeTicketsRequest, ICollection<TicketDto>>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public GetAttendeeTicketsHandler(
        IConventionRepository conventionRepository,
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
    }

    public async Task<ICollection<TicketDto>> Handle(GetAttendeeTicketsRequest req, CancellationToken cancellationToken)
    {
        var convention = await _conventionRepository.GetConvention(req.ConventionId);

        if (convention is null)
            throw new NotFoundError($"Convention with id {req.ConventionId} was not found");

        var attendee = convention.Attendees.FirstOrDefault(x => x.AccountId == _userAccessor.User.GetUserId());

        if (attendee is null)
            throw new UnauthorizedError();

        await PerformAuthorizationAsync(req, convention);

        var tickets = attendee.Tickets.Select(x => x.ToDto()).ToList();
        
        return tickets;
    }

    private async Task PerformAuthorizationAsync(GetAttendeeTicketsRequest req, Convention convention)
    {
        var policy = _userAccessor.User.GetUserId() == req.AtendeeId ? Policies.ReadOwnTickets : Policies.ReadTickets;

        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, policy);
    }
}