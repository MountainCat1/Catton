using Account.Application.Dto;
using Account.Application.Features.GoogleAuthentication.CreateGoogleAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Account.Application.Features.GoogleAuthentication;

[ApiController]
[Route("api/auth/google")]
public class AuthenticationController : Controller
{
    private IGoogleAuthProviderService _googleAuthProvider;
    private IMediator _mediator;

    public AuthenticationController(IGoogleAuthProviderService googleAuthProvider, IMediator mediator)
    {
        _googleAuthProvider = googleAuthProvider;
        _mediator = mediator;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> CreateAccount([FromBody] AuthRequestDto authRequestDto)
    {
        var request = new CreateGoogleAccountRequest(authRequestDto.Token);

        var accountDto = await _mediator.Send(request);

        return Ok(accountDto);
    }

    [HttpGet("register")]
    public async Task<IActionResult> Authenticate([FromBody] AuthRequestDto authRequestDto)
    {
        var v = await _googleAuthProvider.ValidateGoogleJwtAsync(authRequestDto.Token);
        
        return Ok(authRequestDto.Token);
    }
}