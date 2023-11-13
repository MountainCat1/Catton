using Catut.Application.Dtos;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Dtos.Ticket;
using ConventionDomain.Application.Features.TicketFeature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conventions.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/conventions/{conventionId}/tickets}")]
public class ConventionTicketController : ControllerBase
{
    private readonly ICommandMediator _commandMediator;
    private readonly IQueryMediator _queryMediator;

    public ConventionTicketController(ICommandMediator commandMediator, IQueryMediator queryMediator)
    {
        _commandMediator = commandMediator;
        _queryMediator = queryMediator;
    }

    [HttpGet]
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