using Ardalis.Result;
using Ardalis.Specification;
using MediatR;
using PhonebookApp.Core.Abstractions;
using PhonebookApp.Core.Aggregates.ContactAggregate;

namespace PhonebookApp.UseCases.Contacts.Get;

public record GetContactQuery(int Id) : IRequest<Result<ContactDetailDto>>;

internal sealed class GetContactQueryHandler : IRequestHandler<GetContactQuery, Result<ContactDetailDto>>
{
    private readonly IReadRepository<Contact> _repository;

    public GetContactQueryHandler(IReadRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task<Result<ContactDetailDto>> Handle(GetContactQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetContactSpec(request.Id);
        var contact = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        if (contact == null)
        {
            return Result<ContactDetailDto>.NotFound();
        }

        return Result.Success(contact.ToDetailDto());
    }
}

internal sealed class GetContactSpec : Specification<Contact>
{
    public GetContactSpec(int id)
    {
        Query.Where(x => x.Id == id);
    }
}