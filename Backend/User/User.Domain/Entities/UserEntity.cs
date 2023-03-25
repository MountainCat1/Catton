using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Domain.Entities;

public class UserEntity
{
    public UserEntity(string username, string passwordHash)
    {
        Username = username;
        PasswordHash = passwordHash;
    }

    [Key]
    public Guid Guid { get; set; }
   
    public string Username { get; set; }
    public string PasswordHash { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime DateCreated { get; set; }
}