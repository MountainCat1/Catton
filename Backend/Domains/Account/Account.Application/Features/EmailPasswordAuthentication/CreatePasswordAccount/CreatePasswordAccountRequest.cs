using Account.Contracts;
using LanguageExt.Common;
using MediatR;

namespace Account.Application.Features.EmailPasswordAuthentication.CreatePasswordAccount;

public class CreatePasswordAccountRequest : IRequest<Result<AccountDto>>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}