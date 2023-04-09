using System.Security.Claims;
using Account.Application.Abstractions;
using Account.Application.Services;
using Account.Domain.Entities;
using Account.Domain.Repositories;
using LanguageExt.Common;

namespace Account.Application.Features.EmailPasswordAuthentication.AuthViaPassword;

public class AuthViaPasswordRequestHandler : IResultRequestHandler<AuthViaPasswordRequest, AuthViaPasswordResponseDto>
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

    public async Task<Result<AuthViaPasswordResponseDto>> Handle(AuthViaPasswordRequest request, CancellationToken cancellationToken)
    {
        var account = await _passwordAccountRepository
            .GetOneAsync(x => x.Email == request.Email);

        if (account is null)
            return new Result<AuthViaPasswordResponseDto>(new UnauthorizedAccessException());
        
        if(!_hashingService.VerifyPassword(account.PasswordHash, request.Password))
            return new Result<AuthViaPasswordResponseDto>(new UnauthorizedAccessException());
        
        var jwt = _jwtService.GenerateAsymmetricJwtToken(account);

        return new AuthViaPasswordResponseDto()
        {
            Token = jwt
        };
    }
}