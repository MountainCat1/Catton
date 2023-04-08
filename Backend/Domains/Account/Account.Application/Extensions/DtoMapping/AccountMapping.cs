using Account.Application.Dto;
using Account.Application.Features.GoogleAuthentication;
using Account.Domain.Entities;

namespace Account.Application.Extensions.DtoMapping;

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
}