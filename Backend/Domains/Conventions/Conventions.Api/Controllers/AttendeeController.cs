using Catut.Application.Dtos;
using ConventionDomain.Application.Abstractions;
using ConventionDomain.Application.Dtos.Attendee;
using ConventionDomain.Application.Features.AttendeeFeature;
using ConventionDomain.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conventions.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/conventions/{conventionId}/attendees")]
public class AttendeeController : ControllerBase
{
    private readonly ICommandMediator _commandMediator;
    private readonly IQueryMediator _queryMediator;
    private readonly IUserAccessor _userAccessor;

    public AttendeeController(
        ICommandMediator commandMediator,
        IQueryMediator queryMediator,
        IUserAccessor userAccessor)
    {
        _commandMediator = commandMediator;
        _queryMediator = queryMediator;
        _userAccessor = userAccessor;
    }

    [HttpGet("{accountId:guid}")]
    [ProducesResponseType(typeof(AttendeeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAttendee(
        [FromRoute] string conventionId,
        [FromRoute] Guid accountId)
    {
        var query = new GetAttendeeRequest()
        {
            AccountId = accountId,
            ConventionId = conventionId
        };

        var result = await _queryMediator.SendAsync(query);

        return Ok(result);
    }
    [HttpGet]
    [ProducesResponseType(typeof(ICollection<AttendeeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAttendees(
        [FromRoute] string conventionId)
    {
        var query = new GetAttendeesRequest()
        {
            ConventionId = conventionId
        };

        var result = await _queryMediator.SendAsync(query);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AttendeeDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAttendee(
        [FromRoute] string conventionId,
        [FromBody] AttendeeCreateDto createDto)
    {
        ICommand<AttendeeDto> command = new AddAttendeeRequest()
        {
            ConventionId = conventionId,
            AttendeeCreateDto = createDto
        };

        var result = await _commandMediator.SendAsync(command);

        return CreatedAtAction( 
            actionName: nameof(GetAttendee),
            value: result, 
            routeValues: new { conventionId = conventionId, accountId = result.AccountId });
    }

    [HttpPost("me")]
    [ProducesResponseType(typeof(AttendeeDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SignUp([FromRoute] string conventionId)
    {
        var command = new SignUpAsAttendeeCommand()
        {
            ConventionId = conventionId,
        };
        
        var result = await _commandMediator.SendAsync(command);
        
        return CreatedAtAction(
            actionName: nameof(GetAttendee),
            value: result,
            routeValues: new { conventionId = conventionId, accountId = result.AccountId });
    }
    
    [HttpDelete("{accountId:guid}")]
    [ProducesResponseType(typeof(AttendeeDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SignUp([FromRoute] string conventionId, [FromRoute] Guid accountId)
    {
        var command = new RemoveAttendeeRequest()
        {
            ConventionId = conventionId,
            AccountId = accountId
        };
        
        var result = await _commandMediator.SendAsync(command);
        
        return Ok(result);
    }
}