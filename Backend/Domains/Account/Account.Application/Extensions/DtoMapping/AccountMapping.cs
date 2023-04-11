using Account.Domain.Entities;
using Account.Service.Dtos;

namespace Account.Service.Extensions.DtoMapping;

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
         Email = entity.Email,
         Username = entity.Username
      };
   }
}