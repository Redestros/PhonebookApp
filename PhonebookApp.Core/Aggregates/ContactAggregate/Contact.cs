using PhonebookApp.Core.Abstractions;

namespace PhonebookApp.Core.Aggregates.ContactAggregate;

public class Contact : Entity, IAggregateRoot
{
    //For Entity Framework
    #pragma warning disable CS8618
    protected Contact()
    {
    }
    public Contact(string firstName, string lastName, string email, string phone)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new InvalidOperationException("First name should not be empty");
        }
        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new InvalidOperationException("Last name should not be empty");
        }
        if (string.IsNullOrWhiteSpace(phone))
        {
            throw new InvalidOperationException("Phone should not be empty");
        }
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    public string Name => $"{FirstName} {LastName}";
}