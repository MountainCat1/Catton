using Account.Domain.Abstractions;

namespace Account.Contracts.Abstractions;

public interface IDto
{
}
public interface IDto<T> : IDto where T : IEntity
{
}