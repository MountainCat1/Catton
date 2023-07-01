using Accounts.Domain.Entities;
using Accounts.Service.Dtos;

namespace Accounts.Service.Extensions.DtoMapping;

public static class AccountMapping
{
   public static GoogleAccountDto ToDto(this GoogleAccountEntity entity)
   {
      return new GoogleAccountDto()
      {
         Email = entity.Email,
         Username = entity.Username
      };
   }
   
   public static AccountDto ToDto(this AccountEntity entity)
   {
      return new AccountDto()
      {
         Id = entity.Id,
         Email = entity.Email,
         Username = entity.Username,
      };
   }
}