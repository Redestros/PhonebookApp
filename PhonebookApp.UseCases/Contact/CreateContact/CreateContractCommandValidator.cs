using FluentValidation;

namespace PhonebookApp.UseCases.Contact.CreateContact;

public class CreateContractCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContractCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();

        RuleFor(x => x.LastName).NotEmpty();

        RuleFor(x => x.Phone).NotEmpty();
    }
}