using Catut.Infrastructure.Exception;

namespace Catut.Infrastructure.Abstractions;

public interface IDatabaseErrorMapper
{
    public System.Exception Map(DatabaseException exception);
}