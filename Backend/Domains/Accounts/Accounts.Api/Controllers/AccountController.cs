using Accounts.Service.Dtos;
using Accounts.Service.Dtos.Responses;
using Accounts.Service.Features.Account;
using Accounts.Service.Features.EmailPasswordAuthentication;
using Catut.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.Application.Controllers;

/// <summary>
/// AccountController is responsible for handling account-related actions in the API.
/// This includes user authentication, account registration, and retrieval of account details.
/// It uses the MediatR library for handling requests.
/// </summary>
[ApiController]
[Route("api/accounts")]
public class AccountController : Controller
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Authenticates a user with email and password, returning a token upon success.
    /// </summary>
    /// <param name="requestContract">The authentication request contract</param>
    /// <returns>An AuthTokenResponseContract on successful authentication</returns>
    /// <response code="200">Returns an AuthTokenResponseContract on successful authentication</response>
    /// <response code="403">Returns an ErrorResponse on authentication failure</response>
    [HttpPost("login", Name = "Authenticate")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(AuthTokenResponseContract), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Authenticate([FromBody] AuthViaPasswordRequestContract requestContract)
    {
        var request = new AuthViaPasswordRequest(requestContract);

        var result = await _mediator.Send(request);

        return Ok(result);
    }

    /// <summary>
    /// Registers a new account with the provided details.
    /// </summary>
    /// <param name="requestContract">The account registration request contract</param>
    /// <returns>A success message or empty response on successful account creation</returns>
    /// <response code="200">Returns a success message or empty response on successful account creation</response>
    /// <response code="400">Returns a string message in case of an invalid request</response>
    [HttpPost(Name = "RegisterAccount")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAccount([FromBody] CreatePasswordAccountRequestContract requestContract)
    {
        var request = new CreatePasswordAccountRequest(requestContract);

        await _mediator.Send(request);

        return Ok();
    }

    /// <summary>
    /// Retrieves account details for a specific account ID.
    /// </summary>
    /// <param name="id">The unique identifier of the account</param>
    /// <returns>The account details if found</returns>
    /// <response code="200">Returns the account details if found</response>
    /// <response code="404">Returns an ErrorResponse if the account is not found</response>
    [HttpGet("{id:guid}", Name = "GetAccount")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(AccountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAccount([FromRoute] Guid id)
    {
        var request = new GetAccountRequest()
        {
            AccountId = id
        };

        var result = await _mediator.Send(request);

        return Ok(result);
    }

    /// <summary>
    /// Retrieves the account details of the currently authenticated user.
    /// </summary>
    /// <returns>The account details of the authenticated user</returns>
    /// <response code="200">Returns the account details of the authenticated user</response>
    /// <response code="401">Returns an ErrorResponse if the user is unauthorized</response>
    /// <response code="404">Returns an ErrorResponse if the account is not found</response>
    [HttpGet("me", Name = "GetMyAccount")]
    [Authorize]
    [ProducesResponseType(typeof(AccountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetMyAccount()
    {
        var request = new GetMyAccountRequest();
        
        var result = await _mediator.Send(request);

        return Ok(result);
    }
}
