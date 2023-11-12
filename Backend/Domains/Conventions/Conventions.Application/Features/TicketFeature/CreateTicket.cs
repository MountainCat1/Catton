using Catut.Application.Errors;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Dtos.Ticket;
using Conventions.Domain.Repositories;
using MediatR;

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

    public CreateTicketRequestHandler(IConventionRepository conventionRepository)
    {
        _conventionRepository = conventionRepository;
    }

    public async Task<TicketDto> Handle(CreateTicketRequest request, CancellationToken cancellationToken)
    {
        var dto = request.TicketCreateDto;

        var convention = await _conventionRepository.GetConvention(request.ConventionId);

        if (convention is null)
            throw new NotFoundError($"The convention ({request.ConventionId}) could not be found.");

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
}