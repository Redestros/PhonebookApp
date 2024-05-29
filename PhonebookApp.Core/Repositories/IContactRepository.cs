using PhonebookApp.Core.Abstractions;
using PhonebookApp.Core.Aggregates.ContactAggregate;

namespace PhonebookApp.Core.Repositories;

public interface IContactRepository : IRepository<Contact>
{
    Task<Contact?> GetByIdAsync(int id);
    bool Exists(string firstName, string lastName);
    Task<Contact> AddAsync(Contact contact);
}