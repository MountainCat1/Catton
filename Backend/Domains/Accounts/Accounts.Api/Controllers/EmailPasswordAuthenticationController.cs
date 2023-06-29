using Accounts.Service.Dtos.Responses;
using Accounts.Service.Features.EmailPasswordAuthentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.Application.Controllers;

[ApiController]
[Route("api/authentication")]
public class EmailPasswordAuthenticationController : Controller
{
    private readonly IMediator _mediator;

    public EmailPasswordAuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("auth")]
    [AllowAnonymous]
    [ProducesResponseType( typeof(AuthTokenResponseContract), StatusCodes.Status200OK)]
    [ProducesResponseType( StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Authenticate([FromBody] AuthViaPasswordRequestContract requestContract)
    {
        var request = new AuthViaPasswordRequest(requestContract);

        var result = await _mediator.Send(request); 

        return Ok(result);
    }
    
    [HttpPost("register")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAccount([FromBody] CreatePasswordAccountRequestContract requestContract)
    {
        var request = new CreatePasswordAccountRequest(requestContract);

        await _mediator.Send(request);

        return Ok();
    }
}