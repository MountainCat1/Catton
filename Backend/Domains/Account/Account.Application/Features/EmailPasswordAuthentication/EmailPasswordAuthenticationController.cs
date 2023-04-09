using Account.Application.Extensions;
using Account.Application.Features.EmailPasswordAuthentication.AuthViaPassword;
using Account.Application.Features.EmailPasswordAuthentication.CreatePasswordAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Account.Application.Features.EmailPasswordAuthentication;

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
    public async Task<IActionResult> Authenticate([FromBody] AuthViaPasswordDto dto) // <...>Dto - to co przychodzi z front endu
    {
        var request = new AuthViaPasswordRequest(dto);

        var result = await _mediator.Send(request); 

        return result.ToOk();
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAccount([FromBody] CreatePasswordAccountDto dto)
    {
        var request = new CreatePasswordAccountRequest(dto);

        var result = await _mediator.Send(request);

        return result.ToOk();
    }
}