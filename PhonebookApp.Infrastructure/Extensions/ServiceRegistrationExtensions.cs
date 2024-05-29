using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhonebookApp.Core.Abstractions;
using PhonebookApp.Core.Repositories;
using PhonebookApp.Infrastructure.Repositories;

namespace PhonebookApp.Infrastructure.Extensions;

public static class ServiceRegistrationExtensions
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
        });

        services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

        services.AddScoped<IContactRepository, ContactRepository>();
    }
}