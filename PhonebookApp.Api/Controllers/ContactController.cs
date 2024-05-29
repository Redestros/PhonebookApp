using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhonebookApp.UseCases.Contacts;
using PhonebookApp.UseCases.Contacts.Create;
using PhonebookApp.UseCases.Contacts.List;

namespace PhonebookApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
[TranslateResultToActionResult]
public class ContactController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContactController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetContractsRequest request,
        [FromQuery] int page, [FromQuery] int size)
    {
        var query = new GetContractsQuery(request.FirstName, request.LastName, request.Phone,
            request.Email, page, size);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<Result<ContractDto>> Create(CreateContactRequest request)
    {
        var command = new CreateContactCommand(request.FirstName,
            request.LastName, request.Email, request.Phone);

        var result = await _mediator.Send(command);
        return result;
    }
}