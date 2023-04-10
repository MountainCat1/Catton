using Account.Domain.DomainEvents;
using Account.Domain.Entities;
using Account.Domain.Repositories;
using Account.Service.Abstractions;
using Account.Service.Services;
using LanguageExt;
using LanguageExt.Common;

namespace Account.Service.Features.EmailPasswordAuthentication.CreatePasswordAccount;

public class CreatePasswordAccountRequestHandler : IResultRequestHandler<CreatePasswordAccountRequest>
{
    private readonly IPasswordAccountRepository _passwordAccountRepository;
    private readonly IHashingService _hashingService;
    
    public CreatePasswordAccountRequestHandler(IPasswordAccountRepository passwordAccountRepository, IHashingService hashingService)
    {
        _passwordAccountRepository = passwordAccountRepository;
        _hashingService = hashingService;
    }

    public async Task<Result<Unit>> Handle(CreatePasswordAccountRequest request, CancellationToken cancellationToken)
    {
        var googleAccount = new PasswordAccountEntity(
            email: request.Email,
            username: request.Username,
            passwordHash: _hashingService.HashPassword(request.Password)
        );

        await _passwordAccountRepository.AddAsync(googleAccount);

        var dbException = await _passwordAccountRepository.SaveChangesAsync();

        if (dbException is not null)
            return new Result<Unit>(dbException);
        
        return new Result<Unit>(Unit.Default);
    }
}