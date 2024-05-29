using Ardalis.Result;
using MediatR;
using PhonebookApp.Core.Repositories;

namespace PhonebookApp.UseCases.Contacts.Update;

public sealed class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Result<bool>>
{
    private readonly IContactRepository _repository;

    public UpdateContactCommandHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<bool>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _repository.GetByIdAsync(request.Id);
        if (contact == null)
        {
            return Result<bool>.NotFound();
        }

        contact.Update(request.FirstName, request.LastName, request.Phone, request.Email);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return Result<bool>.Success(true);
    }
}