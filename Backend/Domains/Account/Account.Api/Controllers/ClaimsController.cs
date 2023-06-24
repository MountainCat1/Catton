using Account.Service.Features.GetClaims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Account.Application.Controllers;

[ApiController]
[Route("api/authentication/claims")]
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
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetClaims()
    {
        var mediatorRequest = new GetClaimsRequest(User);

        var mediatorResult = await _mediator.Send(mediatorRequest);

        return Ok(mediatorResult);
    }
}