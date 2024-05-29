using Ardalis.Result;
using MediatR;
using PhonebookApp.Core.Repositories;

namespace PhonebookApp.UseCases.Contacts.Delete;

public record DeleteContactCommand(int Id) : IRequest<Result>;

internal sealed class DeleteContactHandler : IRequestHandler<DeleteContactCommand, Result>
{
    private readonly IContactRepository _repository;

    public DeleteContactHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _repository.GetByIdAsync(request.Id);
        if (contact == null)
        {
            return Result.NotFound();
        }
        _repository.Delete(request.Id);
        await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return Result.NoContent();
    }
}