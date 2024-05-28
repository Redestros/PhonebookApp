using PhonebookApp.Core.Abstractions;

namespace PhonebookApp.Core.Aggregates.UserAggregate;

public class User : Entity, IAggregateRoot
{
    //For Entity Framework
    #pragma warning disable CS8618
    protected User()
    {
    }
    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; }
    public string Email { get; set; }
    private readonly List<Contact> _contacts = [];
    public IReadOnlyCollection<Contact> Contacts => _contacts.AsReadOnly();

    public void AddContact(Contact contact)
    {
        //Since a user may have many contracts (>200), it is more performant
        //to check that a contact exists using repositories instead loading all
        //contacts in memory.
        _contacts.Add(contact);
    }
}