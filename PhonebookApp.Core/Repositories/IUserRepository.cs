using PhonebookApp.Core.Abstractions;
using PhonebookApp.Core.Aggregates;
using PhonebookApp.Core.Aggregates.UserAggregate;

namespace PhonebookApp.Core.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByIdAsync(int id);
    Task<Contact> AddContactAsync(int userId, Contact contact);
}