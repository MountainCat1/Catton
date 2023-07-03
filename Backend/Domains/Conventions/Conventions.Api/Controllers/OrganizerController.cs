using Catut.Application.Dtos;
using ConventionDomain.Application.Dtos.Organizer;
using ConventionDomain.Application.Features.OrganizerFeature;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conventions.Api.Controllers;

[ApiController]
[Route("api/conventions/{conventionId:guid}/organizers")]
public class OrganizerController : Controller
{
    private readonly IMediator _mediator;

    public OrganizerController(IMediator mediator, IAuthorizationService authorizationService)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(OrganizerDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateOrganizer(
        [FromRoute] Guid conventionId,
        [FromBody] OrganizerCreateDto createDto)
    {
        var request = new CreateOrganizerRequest()
        {
            OrganizerCreateDto = createDto,
            ConventionId = conventionId
        };

        var createdOrganizer = await _mediator.Send(request);
        
        string resourceUri = Url.Action("GetOrganizer", "Organizer", new { ticketTemplateId = conventionId })
                             ?? throw new InvalidOperationException();

        return Created(resourceUri, createdOrganizer);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(OrganizerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOrganizer([FromRoute] Guid conventionId, [FromRoute] Guid organizerId)
    {
        var request = new GetOrganizerRequest()
        {
            ConventionId = conventionId,
            OrganizerId = organizerId
        };

        var organizer = await _mediator.Send(request);
        
        return Ok(organizer);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(ICollection<OrganizerDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOrganizers([FromRoute] Guid conventionId)
    {
        var request = new GetOrganizersRequest()
        {
            ConventionId = conventionId,
        };

        var organizer = await _mediator.Send(request);
        
        return Ok(organizer);
    }
}