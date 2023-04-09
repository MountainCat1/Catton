using Account.Application.Abstractions;
using Account.Application.Services;
using Account.Domain.Repositories;
using LanguageExt.Common;

namespace Account.Application.Features.EmailPasswordAuthentication.AuthViaPassword;

public class AuthViaPasswordRequestHandler : IResultRequestHandler<AuthViaPasswordRequest, string>
{
    private readonly IPasswordAccountRepository _passwordAccountRepository;
    private readonly IHashingService _hashingService;

    public AuthViaPasswordRequestHandler(
        IHashingService hashingService, 
        IPasswordAccountRepository passwordAccountRepository)
    {
        _hashingService = hashingService;
        _passwordAccountRepository = passwordAccountRepository;
    }

    public async Task<Result<string>> Handle(AuthViaPasswordRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}