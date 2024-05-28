using Ardalis.Specification;

namespace PhonebookApp.Core.Abstractions;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T: class, IAggregateRoot
{
    
}