using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketTemplateDomain.Application.Dtos;
using TicketTemplateDomain.Application.Features.TicketTemplates;

namespace TicketTemplateDomain.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/ticket-templates")]
public class TicketController : Controller
{
    private readonly IMediator _mediator;

    public TicketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(TicketTemplateDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(TicketTemplateCreateDto createDto)
    {
        var request = new CreateTicketTemplateRequest()
        {
            TicketTemplateCreateDto = createDto
        };

        var createdResource = await _mediator.Send(request);

        string resourceUrl = Url.Action("GetTicket", "Ticket", new { ticketTemplateId = createdResource.Id })
                             ?? throw new InvalidOperationException();

        return Created(resourceUrl, createdResource);
    }

    [HttpGet("{ticketTemplateId}")]
    [Produces(typeof(TicketTemplateDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTicket([FromRoute] Guid ticketTemplateId)
    {
        throw new NotImplementedException();
    }
}