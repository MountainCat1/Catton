using ConventionDomain.Application.Dtos;
using ConventionDomain.Application.Features.CreateConvention;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ConventionDomain.Api.Controllers;

[ApiController]
[Route("api/convention")]
public class ConventionController : Controller
{
    private readonly IMediator _mediator;

    public ConventionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateConventionDto createDto)
    {
        var request = new CreateConventionRequest()
        {
            CreateDto = createDto
        };

        await _mediator.Send(request);

        return Ok();
    }
    
    [HttpGet("/{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var request = new GetConventionRequest()
        {
            Id = id
        };

        var result = await _mediator.Send(request);

        return Ok(result);
    }
}