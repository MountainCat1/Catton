using Account.Domain.Entities;

namespace Account.Service.Services.Abstractions;
public interface IAuthProviderService<TAccount> where TAccount : AccountEntity
{

}