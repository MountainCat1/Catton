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

public class CreateTicketRequest : ICommand<TicketDto>
{
    public required TicketCreateDto TicketCreateDto { get; init; }
    public required Guid AttendeeId { get; init; }
    public required string ConventionId { get; init; }
}

public class CreateTicketRequestHandler : IRequestHandler<CreateTicketRequest, TicketDto>
{
    private readonly IConventionRepository _conventionRepository;
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserAccessor _userAccessor;

    public CreateTicketRequestHandler(
        IConventionRepository conventionRepository,
        IAuthorizationService authorizationService,
        IUserAccessor userAccessor)
    {
        _conventionRepository = conventionRepository;
        _authorizationService = authorizationService;
        _userAccessor = userAccessor;
    }

    public async Task<TicketDto> Handle(CreateTicketRequest request, CancellationToken cancellationToken)
    {
        var dto = request.TicketCreateDto;

        var convention = await _conventionRepository.GetConvention(request.ConventionId);

        if (convention is null)
            throw new NotFoundError($"The convention ({request.ConventionId}) could not be found.");

        await PerformAuthorizationAsync(convention, request.AttendeeId, _userAccessor);

        var ticketTemplate = convention.TicketTemplates.FirstOrDefault(x => x.Id == dto.TicketTemplateId);

        if (ticketTemplate is null)
            throw new NotFoundError(
                $"The ticket template ({request.TicketCreateDto.TicketTemplateId}) could not be found.");

        var attendee = convention.Attendees.FirstOrDefault(x => x.AccountId == request.AttendeeId);

        if (attendee is null)
            throw new NotFoundError($"The attendee ({request.AttendeeId}) could not be found.");

        var ticket = attendee.AddTicket(ticketTemplate);

        return ticket.ToDto();
    }

    private async Task PerformAuthorizationAsync(Convention convention, Guid attendeeId, IUserAccessor userAccessor)
    {
        var policy = attendeeId == userAccessor.User.GetUserId() ? Policies.CreateOwnTicket : Policies.CreateTicket;
        
        await _authorizationService.AuthorizeAndThrowAsync(_userAccessor.User, convention, policy);
    }
}