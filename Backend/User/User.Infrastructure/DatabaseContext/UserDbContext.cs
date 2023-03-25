using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;

namespace User.Infrastructure.DatabaseContext;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
}