using Account.Application.Extensions;
using LanguageExt.Pipes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;

namespace Account.Application.Features.GetClaims;

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
    public async Task<IActionResult> GetClaims()
    {
        var mediatorRequest = new GetClaimsRequest(User);

        var mediatorResult = await _mediator.Send(mediatorRequest);

        return mediatorResult.ToOk();
    }
}