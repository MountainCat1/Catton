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

public class DeleteTicketRequest : ICommand<TicketDto>
{
    public Guid TicketId { get; init; }
    public Guid AttendeeId { get; init; }
    public string ConventionId { get; init; }
}

public class DeleteTicketRequestHandler : IRequestHandler<DeleteTicketRequest, TicketDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public DeleteTicketRequestHandler(
        IConventionRepository conventionRepository,
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
    }

    public async Task<TicketDto> Handle(DeleteTicketRequest req, CancellationToken cancellationToken)
    {
        var convention = await _conventionRepository.GetConvention(req.ConventionId);

        if (convention is null)
            throw new NotFoundError($"The convention ({req.ConventionId}) could not be found.");

        await PerformAuthorizationAsync(convention, req.AttendeeId, _userAccessor);

        var attendee = convention.Attendees.FirstOrDefault(x => x.Id == req.AttendeeId);

        if (attendee is null)
            throw new NotFoundError($"The attendee ({req.AttendeeId}) could not be found.");

        var ticket = attendee.Tickets.FirstOrDefault(x => x.Id == req.TicketId);
        
        if(ticket is null)
            throw new NotFoundError($"The ticket ({req.TicketId}) could not be found.");

        attendee.RemoveTicket(ticket);
        
        return ticket.ToDto();
    }

    private async Task PerformAuthorizationAsync(Convention convention, Guid attendeeId, IUserAccessor userAccessor)
    {
        var policy = attendeeId == userAccessor.User.GetUserId() ? Policies.DeleteOwnTicket : Policies.DeleteTicket;
        
        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, policy);
    }
}
