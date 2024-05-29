using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhonebookApp.UseCases.Behaviors;
using PhonebookApp.UseCases.Contacts.Create;

namespace PhonebookApp.UseCases.Extensions;

public static class ServiceRegistrationExtensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining(typeof(ServiceRegistrationExtensions));

            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        
        services.AddValidatorsFromAssemblyContaining<CreateContractCommandValidator>();
        services.AddProblemDetails();
        
        services.AddControllers();
    }
    
}