using Ardalis.Result;
using MediatR;
using PhonebookApp.Core.Aggregates.ContactAggregate;
using PhonebookApp.Core.Repositories;
using PhonebookApp.Shared;

namespace PhonebookApp.UseCases.Contacts.Create;

public class CreateContactCommand : IRequest<Result<ContactDto>>
{
    public CreateContactCommand(string firstName, string lastName, string email, string phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Phone { get; }
}

internal sealed class
    CreateContactHandler : IRequestHandler<CreateContactCommand, Result<ContactDto>>
{
    private readonly IContactRepository _repository;

    public CreateContactHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ContactDto>> Handle(CreateContactCommand request,
        CancellationToken cancellationToken)
    {
        var contact = new Contact(request.FirstName, request.LastName, request.Email,
            request.Phone);

        var phoneExists = _repository.Exists(contact.Phone);

        if (phoneExists)
        {
            return Result<ContactDto>.Conflict($"A contact with phone {contact.Phone} exists.");
        }

        var nameExists = _repository.Exists(contact.FirstName, contact.LastName);

        if (nameExists)
        {
            return Result<ContactDto>.Conflict($"A contact with name {contact.Name} exists.");
        }

        var createdContact = await _repository.AddAsync(contact);
        return Result.Success(new ContactDto(
            createdContact.Id,
            createdContact.Name,
            createdContact.Phone,
            createdContact.Email
        ));
    }
}