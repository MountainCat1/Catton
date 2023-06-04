using Account.Domain.Entities;
using FluentValidation;

namespace Account.Domain.Validators;

public class PasswordAccountValidator : AbstractValidator<PasswordAccountEntity>
{
    public PasswordAccountValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
    }
}