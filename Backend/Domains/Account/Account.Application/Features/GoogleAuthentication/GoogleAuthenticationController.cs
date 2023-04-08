using Account.Application.Dto;
using Account.Application.Extensions;
using Account.Application.Features.GoogleAuthentication.CreateGoogleAccount;
using Account.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Account.Application.Features.GoogleAuthentication;

[ApiController]
[Route("api/auth/google")]
public class AuthenticationController : Controller
{
    private IGoogleAuthProviderService _googleAuthProvider;
    private IMediator _mediator;

    private IAccountRepository _accountRepository;

    public AuthenticationController(IGoogleAuthProviderService googleAuthProvider, IMediator mediator,
        IAccountRepository accountRepository)
    {
        _googleAuthProvider = googleAuthProvider;
        _mediator = mediator;
        _accountRepository = accountRepository;
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateAccount([FromBody] AuthRequestDto authRequestDto)
    {
        var request = new CreateGoogleAccountRequest(authRequestDto.Token);

        var result = await _mediator.Send(request);

        return result.ToOk();
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] AuthRequestDto authRequestDto)
    {
        var v = await _googleAuthProvider.ValidateGoogleJwtAsync(authRequestDto.Token);

        return Ok(authRequestDto.Token);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _accountRepository.GetAllAsync());
    }
}