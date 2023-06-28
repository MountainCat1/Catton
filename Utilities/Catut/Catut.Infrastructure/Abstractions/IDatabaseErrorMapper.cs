namespace Catut.Infrastructure.Abstractions;

public interface IDatabaseErrorMapper
{
    public Exception Map(DatabaseException exception);
}