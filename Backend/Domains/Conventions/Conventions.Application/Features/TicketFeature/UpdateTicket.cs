using Catut.Application.Abstractions;
using Catut.Application.Errors;
using Catut.Application.Services;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Ticket;
using ConventionDomain.Application.Extensions;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.TicketFeature;

public class UpdateTicketRequest : ICommand<TicketDto>
{
    public required TicketUpdateDto UpdateDto { get; init; }
    public required Guid AttendeeId { get; init; }
    public required Guid TicketId { get; init; }
    public required string ConventionId { get; init; }
}

public class UpdateTicketRequestHandler : IRequestHandler<UpdateTicketRequest, TicketDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public UpdateTicketRequestHandler(
        IConventionRepository conventionRepository,
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
    }

    public async Task<TicketDto> Handle(UpdateTicketRequest req, CancellationToken cancellationToken)
    {
        var convention = await _conventionRepository.GetConvention(req.ConventionId);

        if (convention is null)
            throw new NotFoundError($"The convention ({req.ConventionId}) could not be found.");

        var attendee = convention.Attendees.FirstOrDefault(x => x.AccountId == req.AttendeeId);

        if (attendee is null)
            throw new UnauthorizedError();
        
        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.UpdateTicket);
                
        var ticket = attendee.Tickets.FirstOrDefault(x => x.Id == req.TicketId);
        
        if(ticket is null)
            throw new NotFoundError($"The ticket ({req.TicketId}) could not be found.");

        ticket.Update( /*Parameters here should be take from UpdateDto */);

        return ticket.ToDto();
    }
}