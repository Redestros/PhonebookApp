using Ardalis.Result;
using MediatR;

namespace PhonebookApp.UseCases.Contacts.Update;

public class UpdateContactCommand : IRequest<Result<bool>>
{
    public UpdateContactCommand(int id, string firstName, string lastName, string email, string phone)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }

    public int Id { get; set; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Phone { get; }
}