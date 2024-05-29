using Microsoft.EntityFrameworkCore;
using PhonebookApp.Core.Aggregates.ContactAggregate;
using PhonebookApp.Core.Repositories;

namespace PhonebookApp.Infrastructure.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly AppDbContext _context;

    public ContactRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Contact?> GetByIdAsync(int id)
    {
        return await _context.Set<Contact>()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public bool Exists(string firstName, string lastName)
    {
        return _context
            .Set<Contact>()
            .Any(x => x.FirstName.Equals(firstName) &&
                      x.LastName.Equals(lastName));
    }

    public bool Exists(string phone)
    {
        return _context
            .Set<Contact>()
            .Any(x => x.Phone.Equals(phone));
    }

    public async Task<Contact> AddAsync(Contact contact)
    {
        _context.Set<Contact>().Add(contact);
        await _context.SaveChangesAsync();
        return contact;
    }
}