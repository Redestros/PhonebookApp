using FluentValidation;
using PhonebookApp.UseCases.Extensions;

namespace PhonebookApp.UseCases.Contacts.Update;

public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
{
    public UpdateContactCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();

        RuleFor(x => x.LastName).NotEmpty();

        RuleFor(x => x.Phone).NotEmpty();

        RuleFor(x => x.Email).IsEmailAddress();
    }
}