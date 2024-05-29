using FluentValidation;

namespace PhonebookApp.UseCases.Contacts.Create;

public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();

        RuleFor(x => x.LastName).NotEmpty();

        RuleFor(x => x.Phone).NotEmpty();
    }
}