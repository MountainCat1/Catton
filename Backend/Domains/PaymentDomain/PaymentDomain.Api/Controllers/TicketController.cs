using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentDomain.Application.Dtos;
using PaymentDomain.Application.Features.ConventionTickets;
using PaymentDomain.Domain.Entities;

namespace PaymentDomain.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/tickets")]
public class TicketController : Controller
{
    private readonly IMediator _mediator;

    public TicketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ConventionTicketDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(ConventionTicketCreateDto createDto)
    {
        var request = new CreateConventionTicketRequest()
        {
            ConventionTicketCreateDto = createDto
        };

        var createdResource = await _mediator.Send(request);

        string resourceUrl = Url.Action("GetTicket", "Ticket", new { ticketId = createdResource.Id })
                             ?? throw new InvalidOperationException();

        return Created(resourceUrl, createdResource);
    }

    [HttpGet("{ticketId}")]
    [Produces(typeof(ConventionTicketDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTicket([FromRoute] Guid ticketId)
    {
        throw new NotImplementedException();
    }
}