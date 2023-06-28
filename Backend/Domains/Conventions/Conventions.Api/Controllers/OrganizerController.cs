using ConventionDomain.Application.Dtos.Organizer;
using ConventionDomain.Application.Features.OrganizerFeature;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Conventions.Api.Controllers;

[ApiController]
[Route("api/conventions/{conventionId:guid}/organizer")]
public class OrganizerController : Controller
{
    private readonly IMediator _mediator;

    public OrganizerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromRoute] Guid conventionId, OrganizerCreateDto createDto)
    {
        var request = new CreateOrganizerRequest()
        {
            CreateDto = createDto
        };

        await _mediator.Send(request);

        return Ok();
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var request = new GetOrganizerRequest()
        {
            Id = id
        };

        var result = await _mediator.Send(request);

        return Ok(result);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid conventionId,[FromRoute] Guid id, [FromBody] OrganizerUpdateDto updateDto)
    {
        var request = new UpdateOrganizerRequest()
        {
            Id = id,
            UpdateDto = updateDto
        };

        await _mediator.Send(request);

        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid conventionId, [FromRoute] Guid id)
    {
        var request = new DeleteOrganizerRequest();

        await _mediator.Send(request);

        return Ok();
    }
}