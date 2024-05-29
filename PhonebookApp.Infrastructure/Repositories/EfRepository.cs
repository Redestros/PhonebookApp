using Ardalis.Specification.EntityFrameworkCore;
using PhonebookApp.Core.Abstractions;

namespace PhonebookApp.Infrastructure.Repositories;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}