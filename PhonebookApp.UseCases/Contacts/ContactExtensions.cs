using PhonebookApp.Core.Aggregates.ContactAggregate;

namespace PhonebookApp.UseCases.Contacts;

public static class ContactExtensions
{
    public static ContactDto ToDto(this Contact contact)
    {
        return new ContactDto(contact.Id, contact.Name, contact.Phone, contact.Email);
    }

    public static ContactDetailDto ToDetailDto(this Contact contact)
    {
        return new ContactDetailDto(contact.Id, contact.FirstName, contact.LastName, contact.Phone, contact.Email);
    }
}