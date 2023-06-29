using Accounts.Domain.Entities;

namespace Accounts.Service.Services.Abstractions;
public interface IAuthProviderService<TAccount> where TAccount : AccountEntity
{

}