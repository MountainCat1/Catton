using Accounts.Domain.Entities;
using FluentValidation;

namespace Accounts.Domain.Validators;

public class PasswordAccountValidator : AbstractValidator<PasswordAccountEntity>
{
    public PasswordAccountValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
    }
}