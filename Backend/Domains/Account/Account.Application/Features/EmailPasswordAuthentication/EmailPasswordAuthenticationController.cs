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

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAccount([FromBody] CreatePasswordAccountModel model)
    {
        var request = new CreatePasswordAccountRequest()
        {
            Email = model.Email,
            Password = model.Password,
        };

        var result = await _mediator.Send(request);

        return result.ToOk(x => x);
    }

    [HttpPost("auth")]
    public async Task<IActionResult> Authenticate([FromBody] AuthViaPasswordModel model)
    {
        var request = new AuthViaPasswordRequest()
        {
            Email = model.Email,
            Password = model.Password,
        };

        var result = await _mediator.Send(request);

        return result.ToOk(x => x);
    }
}