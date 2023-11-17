﻿using Catut.Application.Errors;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Ticket;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Entities;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.TicketFeature;

public class GetTicketRequest : IQuery<TicketDto>
{
    public required string ConventionId { get; init; }
    public required Guid TicketId { get; init; }
}

public class GetTicketsHandler : IRequestHandler<GetTicketRequest, TicketDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public GetTicketsHandler(
        IConventionRepository conventionRepository,
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
    }

    public async Task<TicketDto> Handle(GetTicketRequest req, CancellationToken cancellationToken)
    {
        var convention = await _conventionRepository.GetConvention(req.ConventionId);

        if (convention is null)
            throw new NotFoundError($"Convention with id {req.ConventionId} was not found");

        var ticket = convention.Attendees
            .SelectMany(x => x.Tickets)
            .FirstOrDefault(x => x.Id == req.TicketId);
        
        await PerformAuthorizationAsync(convention, ticket);
        
        if (ticket is null)
        {
            throw new NotFoundError();
        }

        return ticket.ToDto();
    }

    private async Task PerformAuthorizationAsync(Convention convention, Ticket? ticket)
    {
        var attendee = convention.Attendees.FirstOrDefault(x => x.AccountId == _userAccessor.User.GetUserId());

        if (attendee is null)
            throw new UnauthorizedError();
        
        var policy = attendee.Tickets.Contains(ticket) ? Policies.ReadOwnTickets : Policies.ReadTickets;

        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, policy);
    }
}