using Ardalis.Result;
using MediatR;
using PhonebookApp.Core.Aggregates.ContactAggregate;
using PhonebookApp.Core.Repositories;

namespace PhonebookApp.UseCases.Contacts.Create;

public class CreateContactCommand : IRequest<Result<ContractDto>>
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
    CreateContactHandler : IRequestHandler<CreateContactCommand, Result<ContractDto>>
{
    private readonly IContactRepository _repository;

    public CreateContactHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ContractDto>> Handle(CreateContactCommand request,
        CancellationToken cancellationToken)
    {
        var contact = new Contact(request.FirstName, request.LastName, request.Email,
            request.Phone);

        var existingContact = _repository.Exists(contact.FirstName, contact.LastName);

        if (existingContact)
        {
            return Result<ContractDto>.Conflict("");
        }

        var createdContact = await _repository.AddAsync(contact);
        return Result.Success(new ContractDto(
            createdContact.Id,
            createdContact.Name,
            createdContact.Phone,
            createdContact.Email
        ));
    }
}