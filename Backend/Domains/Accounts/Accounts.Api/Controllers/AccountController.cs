using Accounts.Service.Dtos.Responses;
using Accounts.Service.Features.EmailPasswordAuthentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.Application.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController : Controller
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType( typeof(AuthTokenResponseContract), StatusCodes.Status200OK)]
    [ProducesResponseType( StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Authenticate([FromBody] AuthViaPasswordRequestContract requestContract)
    {
        var request = new AuthViaPasswordRequest(requestContract);

        var result = await _mediator.Send(request); 

        return Ok(result);
    }
    
    [HttpPost]
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