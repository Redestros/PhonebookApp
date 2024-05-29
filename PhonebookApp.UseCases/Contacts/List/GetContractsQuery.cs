using Ardalis.Specification;
using MediatR;
using PhonebookApp.Core.Abstractions;
using PhonebookApp.Core.Aggregates.ContactAggregate;

namespace PhonebookApp.UseCases.Contacts.List;

public class GetContractsQuery : IRequest<List<ContractDto>>
{
    public GetContractsQuery(string firstName, string lastName, string phone, string email, int page, int size)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
        Page = page > 0 ? page: 1;
        Size = size > 0 ? size: 5;
    }

    public string FirstName { get; } 
    public string LastName { get; }
    public string Phone { get; } 
    public string Email { get; } 
    public int Page { get; }
    public int Size { get; }
}

internal class GetContractsHandler : IRequestHandler<GetContractsQuery, List<ContractDto>>
{
    private readonly IReadRepository<Contact> _repository;

    public GetContractsHandler(IReadRepository<Contact> repository)
    {
        _repository = repository;
    }

    public async Task<List<ContractDto>> Handle(GetContractsQuery request, CancellationToken cancellationToken)
    {
        var spec = new SearchContractsSpec(request.FirstName, request.LastName,
            request.Phone, request.Email, request.Page, request.Size);
        
        var contracts = await _repository.ListAsync(spec, cancellationToken);
        
        return contracts
            .Select(x => new ContractDto(x.Id, x.Name, x.Phone, x.Email))
            .ToList();
    }
}

internal sealed class SearchContractsSpec : Specification<Contact>
{
    public SearchContractsSpec(string firstName, string lastName, string phone, string email,
        int page, int size)
    {
        if (!string.IsNullOrEmpty(firstName))
        {
            Query.Where(x => x.FirstName.Contains(firstName));
        }
        
        if (!string.IsNullOrEmpty(lastName))
        {
            Query.Where(x => x.LastName.Contains(lastName));
        }
        
        if (!string.IsNullOrEmpty(phone))
        {
            Query.Where(x => x.Phone.Contains(phone));
        }
        
        if (!string.IsNullOrEmpty(email))
        {
            Query.Where(x => x.Email.Contains(email));
        }

        Query.Skip((page - 1) * size)
            .Take(size);
    }
}