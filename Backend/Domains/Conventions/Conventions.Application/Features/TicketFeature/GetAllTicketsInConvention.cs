using Catut.Application.Errors;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Authorization;
using ConventionDomain.Application.Dtos.Ticket;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Services;
using Conventions.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ConventionDomain.Application.Features.TicketFeature;

public class GetAllTicketsInConventionRequest : IQuery<ICollection<TicketDto>>
{
    public required string ConventionId { get; init; }
}

public class GetAllTicketsInConventionHandler : IRequestHandler<GetAllTicketsInConventionRequest, ICollection<TicketDto>>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public GetAllTicketsInConventionHandler(
        IConventionRepository conventionRepository,
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
    }

    public async Task<ICollection<TicketDto>> Handle(GetAllTicketsInConventionRequest req, CancellationToken cancellationToken)
    {
        var convention = await _conventionRepository.GetConvention(req.ConventionId);

        if (convention is null)
            throw new NotFoundError($"Convention with id {req.ConventionId} was not found");
        
        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, Policies.ReadTickets);

        var tickets = convention.Attendees
            .SelectMany(x => x.Tickets)
            .Select(x => x.ToDto())
            .ToList();
        
        return tickets;
    }
}