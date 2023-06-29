using Accounts.Domain.Validators;
using FluentValidation;



namespace Accounts.Domain.Entities;

public class PasswordAccountEntity : AccountEntity
{
    public string PasswordHash { get; set; }

    protected PasswordAccountEntity(string email, string username, string passwordHash) : base(email, username)
    {
        PasswordHash = passwordHash;
    }

    internal static async Task<PasswordAccountEntity> CreateAsync(string email, string username, string passwordHash)
    {
        var newAccount = new PasswordAccountEntity(email, username, passwordHash);

        await newAccount.ValidateAndThrow();

        return newAccount;
    }
    
    public async Task ValidateAndThrow()
    {
        await new PasswordAccountValidator().ValidateAndThrowAsync(this);
    }
}