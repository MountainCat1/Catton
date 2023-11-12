using Accounts.Domain.Repositories;
using Accounts.Domain.Validators;
using Catut.Domain.Errors;
using FluentValidation;



namespace Accounts.Domain.Entities;

public class PasswordAccountEntity : AccountEntity
{
    public string PasswordHash { get; set; }

    protected PasswordAccountEntity(string email, string username, string passwordHash) : base(email, username)
    {
        PasswordHash = passwordHash;
    }

    public static async Task<PasswordAccountEntity> CreateAsync(string email, string username, string passwordHash, IPasswordAccountRepository repository)
    {
        if (await repository.GetAccountByEmailAsync(email) is not null)
            throw new ConflictDomainError("Email has already been taken");
        
        var newAccount = new PasswordAccountEntity(email, username, passwordHash);

        await newAccount.ValidateAndThrow();

        return newAccount;
    }
    
    public async Task ValidateAndThrow()
    {
        await new PasswordAccountValidator().ValidateAndThrowAsync(this);
    }
}