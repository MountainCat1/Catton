using Catut.Application.Dtos;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Dtos.Ticket;
using ConventionDomain.Application.Extensions;
using ConventionDomain.Application.Features.TicketFeature;
using ConventionDomain.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Conventions.Api.Controllers;

[ApiController]
[Route("api/conventions/{conventionId}")]
public class TicketController : Controller
{
    private readonly ICommandMediator _commandMediator;
    private readonly IQueryMediator _queryMediator;
    private readonly IUserAccessor _userAccessor;

    public TicketController(ICommandMediator commandMediator, IUserAccessor userAccessor, IQueryMediator queryMediator)
    {
        _commandMediator = commandMediator;
        _userAccessor = userAccessor;
        _queryMediator = queryMediator;
    }


    [HttpPost("attendees/{attendeeId:guid}/tickets")]
    [ProducesResponseType(typeof(TicketDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateOrganizer(
        [FromRoute] string conventionId,
        [FromRoute] Guid attendeeId,
        [FromBody] TicketCreateDto createDto)
    {
        var request = new CreateTicketRequest()
        {
            ConventionId = conventionId,
            AttendeeId = attendeeId,
            TicketCreateDto = createDto
        };

        var ticket = await _commandMediator.SendAsync(request);

        string resourceUri = Url.Action("GetTicket", "Ticket", new { conventionId = conventionId, attendeeId = attendeeId, ticketId = ticket.Id })
                             ?? throw new InvalidOperationException();

        return Created(resourceUri, ticket);
    }
    
    
    [HttpGet("attendees/{attendeeId:guid}/tickets")]
    [ProducesResponseType(typeof(TicketDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTicket(
        [FromRoute] string conventionId,
        [FromRoute] Guid attendeeId)
    {
        var request = new GetAttendeeTicketsRequest()
        {
            ConventionId = conventionId,
            AtendeeId = attendeeId,
        };
            
        var tickets = await _queryMediator.SendAsync(request);
            
        return Ok(tickets);
    }
    
    [HttpGet("tickets")]
    [ProducesResponseType(typeof(ICollection<TicketDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllTickets(string conventionId)
    {
        var request = new GetAllTicketsInConventionRequest()
        {
            ConventionId = conventionId
        };

        var tickets = await _queryMediator.SendAsync(request);

        return Ok(tickets);
    }
}