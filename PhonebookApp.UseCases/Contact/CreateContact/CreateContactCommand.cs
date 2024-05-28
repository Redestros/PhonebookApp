using MediatR;
using PhonebookApp.Core.Repositories;

namespace PhonebookApp.UseCases.Contact.CreateContact;

public class CreateContactCommand : IRequest<bool>
{
    public CreateContactCommand(int userId, string firstName, string lastName, string email, string phone)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }

    public int UserId { get; set; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Phone { get; }
}

internal sealed class
    CreateContactHandler : IRequestHandler<CreateContactCommand, bool>
{
    private readonly IUserRepository _repository;

    public CreateContactHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(CreateContactCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            throw new InvalidOperationException("User not found.");
        }

        var contact =
            new Core.Aggregates.UserAggregate.Contact(request.FirstName, request.LastName, request.Email,
                request.Phone);

        await _repository.AddContactAsync(request.UserId, contact);
        return true;
    }
}