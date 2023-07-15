using Catut.Application.Dtos;
using ConventionDomain.Application.Dtos.TicketTemplate;
using ConventionDomain.Application.Features.TicketTemplates;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Conventions.Api.Controllers;

[ApiController]
[Route("api/{conventionId:guid}/ticket-templates")]
public class TicketTemplateController : Controller
{
    private readonly IMediator _mediator;

    public TicketTemplateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(TicketTemplateDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create([FromRoute] Guid conventionId, [FromBody] TicketTemplateCreateDto createDto)
    {
        var request = new CreateTicketTemplateRequest()
        {
            ConventionId = conventionId,
            TicketCreateDto = createDto
        };


        var createdTicketTemplate = await _mediator.Send(request);

        string resourceUri = Url.Action("GetTicketTemplate", "TicketTemplate", new
                             {
                                 ticketTemplateId = createdTicketTemplate.Id,
                                 conventionId = createdTicketTemplate.ConvetionId
                             })
                             ?? throw new InvalidOperationException();

        return Created(resourceUri, createdTicketTemplate);
    }

    [HttpGet("{ticketTemplateId:guid}")]
    [ProducesResponseType(typeof(TicketTemplateDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTicketTemplate([FromRoute] Guid conventionId, [FromRoute] Guid ticketTemplateId)
    {
        var request = new GetTicketTemplateRequest()
        {
            ConventionId = conventionId,
            TicketTemplateId = ticketTemplateId
        };

        var ticketTemplate = await _mediator.Send(request);

        return Ok(ticketTemplate);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ICollection<TicketTemplateDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTicketsTemplate([FromRoute] Guid conventionId)
    {
        var request = new GetTicketTemplatesRequest()
        {
            ConventionId = conventionId
        };

        var ticketTemplate = await _mediator.Send(request);

        return Ok(ticketTemplate);
    }

    [HttpPut("{ticketTemplateId:guid}")]
    [ProducesResponseType(typeof(TicketTemplateDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateTicketsTemplate(
        [FromRoute] Guid conventionId,
        [FromRoute] Guid ticketTemplateId,
        [FromBody] TicketTemplateUpdateDto updateDto)
    {
        var request = new UpdateTicketTemplateRequest()
        {
            ConventionId = conventionId,
            TicketTemplateId = ticketTemplateId,
            TicketUpdateDto = updateDto
        };

        var ticketTemplate = await _mediator.Send(request);

        return Ok(ticketTemplate);
    }

    [HttpDelete("{ticketTemplateId:guid}")]
    [ProducesResponseType(typeof(TicketTemplateDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteTicketsTemplate(
        [FromRoute] Guid conventionId,
        [FromRoute] Guid ticketTemplateId)
    {
        var request = new DeleteTicketTemplateRequest()
        {
            ConventionId = conventionId,
            TicketTemplateId = ticketTemplateId
        };

        var ticketTemplate = await _mediator.Send(request);

        return Ok(ticketTemplate);
    }
}