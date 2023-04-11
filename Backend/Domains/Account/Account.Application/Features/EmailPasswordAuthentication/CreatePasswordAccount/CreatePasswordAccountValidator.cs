using FluentValidation;

namespace Account.Service.Features.EmailPasswordAuthentication.CreatePasswordAccount;

public class CreatePasswordAccountValidator : AbstractValidator<CreatePasswordAccountRequest>
{
    private const string PasswordRegex = "^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$";
    //     Contain at least one letter (uppercase or lowercase) using the (?=.*[A-Za-z]) lookahead assertion.
    //     Contain at least one digit using the (?=.*\d) lookahead assertion.
    //     Contain at least one special character from the set @$!%*#?& using the (?=.*[@$!%*#?&]) lookahead assertion.
    ////// Be at least 8 characters long using the {8,} quantifier
    
    
    public CreatePasswordAccountValidator()
    {
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).Matches(PasswordRegex);;
    }
}