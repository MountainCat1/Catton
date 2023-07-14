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
    private IMediator _mediator;

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
        throw new NotImplementedException();
    }
}