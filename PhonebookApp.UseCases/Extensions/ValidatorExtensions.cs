using FluentValidation;
using PhonebookApp.UseCases.Validators;

namespace PhonebookApp.UseCases.Extensions;

public static class ValidatorExtensions
{
    public static IRuleBuilderOptions<TModel, string> IsEmailAddress<TModel>(this IRuleBuilder<TModel, string> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new EmailPropertyValidator<TModel>());
    }
}