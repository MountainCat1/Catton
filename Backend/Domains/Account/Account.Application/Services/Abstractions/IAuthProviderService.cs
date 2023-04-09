using Account.Domain.Entities;

namespace Account.Application.Services.Abstractions;
public interface IAuthProviderService<TAccount> where TAccount : AccountEntity
{

}