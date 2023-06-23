using Account.Domain.Repositories;
using Account.Service.Dtos.Responses;
using Account.Service.Errors;
using Account.Service.Services;
using MediatR;

namespace Account.Service.Features.EmailPasswordAuthentication;

public class AuthViaPasswordRequestContract
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}

public class AuthViaPasswordRequest : IRequest<AuthTokenResponseContract>
{
    public string Email { get; }
    public string Password { get; }

    public AuthViaPasswordRequest(AuthViaPasswordRequestContract requestContract)
    {
        Email = requestContract.Email;
        Password = requestContract.Password;
    }
}

public class AuthViaPasswordRequestHandler : IRequestHandler<AuthViaPasswordRequest, AuthTokenResponseContract>
{
    private readonly IPasswordAccountRepository _passwordAccountRepository;
    private readonly IHashingService _hashingService;
    private readonly IJwtService _jwtService;

    public AuthViaPasswordRequestHandler(
        IHashingService hashingService, 
        IPasswordAccountRepository passwordAccountRepository,
        IJwtService jwtService)
    {
        _hashingService = hashingService;
        _passwordAccountRepository = passwordAccountRepository;
        _jwtService = jwtService;
    }

    public async Task<AuthTokenResponseContract> Handle(AuthViaPasswordRequest request, CancellationToken cancellationToken)
    {
        var account = await _passwordAccountRepository.GetAccountByEmailAsync(request.Email);

        if (account is null)
            throw new UnauthorizedError();
        
        if(!_hashingService.VerifyPassword(account.PasswordHash, request.Password))
            throw new UnauthorizedError();
        
        var jwt = _jwtService.GenerateAsymmetricJwtToken(account);

        return new AuthTokenResponseContract()
        {
            AuthToken = jwt
        };
    }
}