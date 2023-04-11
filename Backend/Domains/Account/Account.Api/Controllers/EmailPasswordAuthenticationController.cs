using Account.Application.Extensions;
using Account.Service.Features.EmailPasswordAuthentication;
using MediatR;
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
    public async Task<IActionResult> Authenticate([FromBody] AuthViaPasswordRequestContract requestContract)
    {
        var request = new AuthViaPasswordRequest(requestContract);

        var result = await _mediator.Send(request); 

        return result.ToOk();
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAccount([FromBody] CreatePasswordAccountRequestContract requestContract)
    {
        var request = new CreatePasswordAccountRequest(requestContract);

        var result = await _mediator.Send(request);

        return result.ToOk();
    }
}