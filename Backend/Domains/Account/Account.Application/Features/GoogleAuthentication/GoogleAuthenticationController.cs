using Account.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Account.Application.Features.GoogleAuthentication;

[ApiController]
[Route("api/auth/google")]
public class AuthenticationController : Controller
{
    private IGoogleAuthProviderService _googleAuthProvider;

    public AuthenticationController(IGoogleAuthProviderService googleAuthProvider)
    {
        _googleAuthProvider = googleAuthProvider;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAccount([FromBody] AuthRequestDto authRequestDto)
    {
        var result = await _googleAuthProvider.ValidateGoogleJwt(authRequestDto.Token);
        
        return Ok(authRequestDto.Token);
    }
    
    [HttpGet]
    public async Task<IActionResult> Authenticate([FromBody] AuthRequestDto authRequestDto)
    {
        var result = await _googleAuthProvider.ValidateGoogleJwt(authRequestDto.Token);
        
        return Ok(authRequestDto.Token);
    }
}