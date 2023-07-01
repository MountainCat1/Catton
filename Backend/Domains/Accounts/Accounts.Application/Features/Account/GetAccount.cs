using System.Security.Claims;
using Accounts.Domain.Repositories;
using Accounts.Service.Dtos;
using Accounts.Service.Dtos.Responses;
using Accounts.Service.Extensions.DtoMapping;
using Catut.Application.Errors;
using MediatR;

namespace Accounts.Service.Features.Account;

public class GetAccountRequest : IRequest<AccountDto>
{
    public required Guid AccountId { get; set; }
}

public class GetAccountRequestRequestHandler : IRequestHandler<GetAccountRequest, AccountDto>
{
    private readonly IAccountRepository _accountRepository;

    public GetAccountRequestRequestHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<AccountDto> Handle(GetAccountRequest request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetOneAsync(request.AccountId);

        if (account is null)
            throw new NotFoundError($"Account with {request.AccountId} does not exist");
        
        return account.ToDto();
    }
}