using Accounts.Service.Features.GetClaims;
using Catut.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.Application.Controllers;

[ApiController]
[Route("api/accounts/claims")]
public class ClaimsController : Controller
{
    private readonly IMediator _mediator;

    public ClaimsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType(typeof(GetClaimsResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType( typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetClaims()
    {
        var mediatorRequest = new GetClaimsRequest(User);

        var mediatorResult = await _mediator.Send(mediatorRequest);

        return Ok(mediatorResult);
    }
}