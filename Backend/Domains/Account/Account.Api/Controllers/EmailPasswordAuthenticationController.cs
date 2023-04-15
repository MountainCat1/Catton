using Account.Service.Dtos.Responses;
using Account.Service.Features.EmailPasswordAuthentication;
using Catut.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Account.Application.Controllers;

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

        return result.ToOk();
    }
    
    [HttpPost("register")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAccount([FromBody] CreatePasswordAccountRequestContract requestContract)
    {
        var request = new CreatePasswordAccountRequest(requestContract);

        var result = await _mediator.Send(request);

        return result.ToOk();
    }
}