using Catut.Application.Dtos;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Dtos.TicketTemplate;
using ConventionDomain.Application.Features.TicketTemplates;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Conventions.Api.Controllers;

[ApiController]
[Route("api/conventions/{conventionId:guid}/ticket-templates")]
public class TicketTemplateController : Controller
{
    private readonly IQueryMediator _queryMediator;
    private readonly ICommandMediator _commandMediator;
    
    public TicketTemplateController(IMediator mediator, IQueryMediator queryMediator, ICommandMediator commandMediator)
    {
        _queryMediator = queryMediator;
        _commandMediator = commandMediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(TicketTemplateDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create([FromRoute] string conventionId, [FromBody] TicketTemplateCreateDto createDto)
    {
        var request = new CreateTicketTemplateRequest()
        {
            ConventionId = conventionId,
            TicketCreateDto = createDto
        };


        var createdTicketTemplate = await _commandMediator.SendAsync(request);

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
    public async Task<IActionResult> GetTicketTemplate([FromRoute] string conventionId, [FromRoute] Guid ticketTemplateId)
    {
        var request = new GetTicketTemplateRequest()
        {
            ConventionId = conventionId,
            TicketTemplateId = ticketTemplateId
        };

        var ticketTemplate = await _queryMediator.SendAsync(request);

        return Ok(ticketTemplate);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ICollection<TicketTemplateDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTicketsTemplate([FromRoute] string conventionId)
    {
        var request = new GetTicketTemplatesRequest()
        {
            ConventionId = conventionId
        };

        var ticketTemplate = await _queryMediator.SendAsync(request);

        return Ok(ticketTemplate);
    }

    [HttpPut("{ticketTemplateId:guid}")]
    [ProducesResponseType(typeof(TicketTemplateDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateTicketsTemplate(
        [FromRoute] string conventionId,
        [FromRoute] Guid ticketTemplateId,
        [FromBody] TicketTemplateUpdateDto updateDto)
    {
        var request = new UpdateTicketTemplateRequest()
        {
            ConventionId = conventionId,
            TicketTemplateId = ticketTemplateId,
            TicketUpdateDto = updateDto
        };

        var ticketTemplate = await _commandMediator.SendAsync(request);

        return Ok(ticketTemplate);
    }

    [HttpDelete("{ticketTemplateId:guid}")]
    [ProducesResponseType(typeof(TicketTemplateDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteTicketsTemplate(
        [FromRoute] string conventionId,
        [FromRoute] Guid ticketTemplateId)
    {
        var request = new DeleteTicketTemplateRequest()
        {
            ConventionId = conventionId,
            TicketTemplateId = ticketTemplateId
        };

        var ticketTemplate = await _commandMediator.SendAsync(request);

        return Ok(ticketTemplate);
    }
}