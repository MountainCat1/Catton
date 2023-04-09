using Account.Application.Abstractions;
using Account.Contracts;
using LanguageExt.Common;

namespace Account.Application.Features.EmailPasswordAuthentication.CreatePasswordAccount;

public class CreatePasswordAccountRequestHandler : IResultRequestHandler<CreatePasswordAccountRequest, AccountDto>
{
    public Task<Result<AccountDto>> Handle(CreatePasswordAccountRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}