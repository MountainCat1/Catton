using Account.Domain.Repositories;
using Account.Service.Abstractions;
using Account.Service.Dtos.Responses;
using Account.Service.Services;
using Catton.Utilities;

namespace Account.Service.Features.EmailPasswordAuthentication;

public class AuthViaPasswordRequestContract
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}


public class AuthViaPasswordRequest : IResultRequest<AuthTokenResponseContract>
{
    public string Email { get; }
    public string Password { get; }

    public AuthViaPasswordRequest(AuthViaPasswordRequestContract requestContract)
    {
        Email = requestContract.Email;
        Password = requestContract.Password;
    }
}

public class AuthViaPasswordRequestHandler : IResultRequestHandler<AuthViaPasswordRequest, AuthTokenResponseContract>
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

    public async Task<Result<AuthTokenResponseContract>> Handle(AuthViaPasswordRequest request, CancellationToken cancellationToken)
    {
        var account = await _passwordAccountRepository
            .GetOneAsync(x => x.Email == request.Email);

        if (account is null)
            return new Result<AuthTokenResponseContract>(new UnauthorizedAccessException());
        
        if(!_hashingService.VerifyPassword(account.PasswordHash, request.Password))
            return new Result<AuthTokenResponseContract>(new UnauthorizedAccessException());
        
        var jwt = _jwtService.GenerateAsymmetricJwtToken(account);

        return new AuthTokenResponseContract()
        {
            AuthToken = jwt
        };
    }
}