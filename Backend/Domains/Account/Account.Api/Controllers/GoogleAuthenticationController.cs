using Account.Domain.Repositories;
using Account.Service.Features.GoogleAuthentication;
using Catut.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Account.Application.Controllers;

[ApiController]
[Route("api/authentication/google")]
public class AuthenticationController : Controller
{
    private readonly IGoogleAuthProviderService _googleAuthProvider;
    private readonly IMediator _mediator;

    private readonly IAccountRepository _accountRepository;

    public AuthenticationController(IGoogleAuthProviderService googleAuthProvider, IMediator mediator,
        IAccountRepository accountRepository)
    {
        _googleAuthProvider = googleAuthProvider;
        _mediator = mediator;
        _accountRepository = accountRepository;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAccount([FromBody] CreateGoogleAccountRequestContract authRequestModel)
    {
        var request = new CreateGoogleAccountRequest(authRequestModel.AuthToken);

        var result = await _mediator.Send(request);

        return result.ToOk();
    }

    [HttpPost("authenticate")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Authenticate([FromBody] AuthiViaGoogleRequestContract requestRequestContract)
    {
        var request = new AuthiViaGoogleRequest()
        {
            GoogleAuthToken = requestRequestContract.AuthToken
        };

        var result = await _mediator.Send(request);
        
        return result.ToOk();
    }
}