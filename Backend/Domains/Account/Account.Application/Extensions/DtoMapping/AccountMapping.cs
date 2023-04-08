using Account.Application.Dto;
using Account.Application.Features.GoogleAuthentication;

namespace Account.Application.Extensions.DtoMapping;

public static class AccountMapping
{
   public static GoogleAccountDto ToDto(this GoogleAccountEntity entity)
   {


      return new GoogleAccountDto()
      {
         Email = entity.Email
      };
   }
}