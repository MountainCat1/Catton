namespace Account.Domain.Entities;

public class GoogleAccountEntity : AccountEntity
{
    public GoogleAccountEntity(string email, string username) : base(email, username)
    {
    }
}