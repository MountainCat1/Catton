using Accounts.Domain.Entities;
using Accounts.Domain.Repositories;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace Accounts.Domain.Services;

public interface IPasswordAccountService
{
    Task<PasswordAccountEntity> CreateAsync(string email, string username, string passwordHash);
}

public class PasswordAccountService : IPasswordAccountService
{
    private readonly IPasswordAccountRepository _passwordAccountRepository;

    public PasswordAccountService(IPasswordAccountRepository passwordAccountRepository)
    {
        _passwordAccountRepository = passwordAccountRepository;
    }

    public async Task<PasswordAccountEntity> CreateAsync(string email, string username, string passwordHash)
    {
        if (await _passwordAccountRepository.GetAccountByEmailAsync(email) is not null)
        {
            throw new ValidationException("Email has already been taken");
        }
        
        var entity = await PasswordAccountEntity.CreateAsync(
            email: email,
            username: username,
            passwordHash: passwordHash
        );

        return entity;
    }
}