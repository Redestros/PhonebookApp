using PhonebookApp.Core.Abstractions;

namespace PhonebookApp.Core.Aggregates;

public class Contact : Entity
{
    
    //For Entity Framework
    #pragma warning disable CS8618
    protected Contact()
    {
    }
    public Contact(string firstName, string lastName, string email, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
}