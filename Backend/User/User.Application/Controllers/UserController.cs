using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations.Rules;
using User.Application.Features.AuthenticateUser;
using User.Application.Features.RegisterUser;

namespace User.Application.Controllers;

[ApiController]
[Route("User")]
public class UserController : Controller
{
    private readonly IMediator _mediator;
    // GET
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto dto)
    {
        var command = new RegisterUserCommand(
            username: dto.Username,
            password: dto.Password);

        await _mediator.Send(command);
        
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserDto authenticateUserDto)
    {
        // TODO
        throw new NotImplementedException();
    }
}