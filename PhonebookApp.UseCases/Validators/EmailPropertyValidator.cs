using FluentValidation;
using FluentValidation.Validators;

namespace PhonebookApp.UseCases.Validators;

public class EmailPropertyValidator<T> : PropertyValidator<T, string>, IRegularExpressionValidator
{
    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return "Email is not valid";
    }

    public override bool IsValid(ValidationContext<T> context, string? value)
    {
        return value == null || CommonHelper.GetEmailRegex().IsMatch(value);
    }
    
    public override string Name => "EmailPropertyValidator";

    public string Expression { get; } = """^(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])$""";
}