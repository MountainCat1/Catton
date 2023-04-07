using System.ComponentModel.DataAnnotations;
using Account.Domain.Abstractions;

namespace Account.Domain.Entities;

public abstract class AccountEntity : IEntity
{
    [Key]
    public Guid Id { get; set; }

    public string Username { get; set; }
    public string Email { get; set; }
}