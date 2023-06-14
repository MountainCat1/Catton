﻿using Account.Domain.Entities;
using Account.Domain.Repositories;
using Account.Service.Abstractions;
using Account.Service.Dtos.Responses;
using Account.Service.Errors;
using Account.Service.Services;
using Catut;
using Google.Apis.Auth;
using MediatR;

namespace Account.Service.Features.GoogleAuthentication;

public class AuthiViaGoogleRequestContract
{
    public required string AuthToken { get; set; }
}

public class AuthiViaGoogleRequest : IRequest<AuthTokenResponseContract>
{
    public required string GoogleAuthToken { get; set; }
}

public class AuthiViaGoogleRequestHandler : IRequestHandler<AuthiViaGoogleRequest, AuthTokenResponseContract>
{
    private IAccountRepository _accountRepository;
    private IGoogleAuthProviderService _authProviderService;
    private IJwtService _jwtService;

    public AuthiViaGoogleRequestHandler(
        IAccountRepository accountRepository,
        IGoogleAuthProviderService authProviderService,
        IJwtService jwtService)
    {
        _accountRepository = accountRepository;
        _authProviderService = authProviderService;
        _jwtService = jwtService;
    }

    public async Task<AuthTokenResponseContract> Handle(AuthiViaGoogleRequest request,
        CancellationToken cancellationToken)
    {
        var payload = await _authProviderService.ValidateGoogleJwtAsync(request.GoogleAuthToken);

        var accountEntity = await _accountRepository.GetAccountByEmailAsync(payload.Email)
                            ?? throw new NotFoundError();

        var jwt = _jwtService.GenerateAsymmetricJwtToken(accountEntity);

        return new AuthTokenResponseContract()
        {
            AuthToken = jwt
        };
    }
}