using Accounts.Domain.Repositories;
using Accounts.Service.Dtos;
using Accounts.Service.Extensions;
using Accounts.Service.Extensions.DtoMapping;
using Accounts.Service.Services;
using MediatR;

namespace Accounts.Service.Features.Account;

public class GetMyAccountRequest : IRequest<AccountDto>
{
}

public class GetMyAccountRequestHandler : IRequestHandler<GetMyAccountRequest, AccountDto>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUserAccessor _userAccessor;
    
    
    public GetMyAccountRequestHandler(IAccountRepository accountRepository, IUserAccessor userAccessor)
    {
        _accountRepository = accountRepository;
        _userAccessor = userAccessor;
    }


    public async Task<AccountDto> Handle(GetMyAccountRequest req, CancellationToken cancellationToken)
    {
        var userId = _userAccessor.User.GetUserId();

        var account = await _accountRepository.GetOneByIdAsync(userId);

        if (account is null)
            throw new NullReferenceException("User tried to retrieve their user info but got null");

        return account.ToDto();
    }
}
