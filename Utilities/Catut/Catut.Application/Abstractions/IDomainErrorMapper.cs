namespace Catut.Application.Abstractions;

public interface IDomainErrorMapper
{
    Exception Map(Exception ex);
}