using Account.Domain.Validators;
using FluentValidation;
using LanguageExt.Common;


namespace Account.Domain.Entities;

public class PasswordAccountEntity : AccountEntity
{
    public string PasswordHash { get; set; }

    protected PasswordAccountEntity(string email, string username, string passwordHash) : base(email, username)
    {
        PasswordHash = passwordHash;
    }

    public static async Task<Result<PasswordAccountEntity>> CreateAsync(string email, string username, string passwordHash)
    {
        var newAccount = new PasswordAccountEntity(email, username, passwordHash);

        var validator = new PasswordAccountValidator();

        var validationResult = await validator.ValidateAsync(newAccount);

        if (!validationResult.IsValid)
        {
            return new Result<PasswordAccountEntity>(new ValidationException(validationResult.Errors));
        }
        
        return newAccount;
    }
}