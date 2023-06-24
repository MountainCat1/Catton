using Catut.Infrastructure.Abstractions;

namespace Catut.Infrastructure.Errors.Database;

public class ItemNotFoundException : DatabaseException
{
    public ItemNotFoundException()
    {
    }

    public ItemNotFoundException(string? message) : base(message)
    {
    }
}