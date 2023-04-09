using Account.Domain.Abstractions;

namespace Account.Contracts.Abstractions;

public interface IDto<T> where T : IEntity
{
}