using MediatR;
using Microsoft.EntityFrameworkCore;
using PhonebookApp.Core.Abstractions;
using PhonebookApp.Infrastructure.EntityConfigurations;
using PhonebookApp.Infrastructure.Extensions;

namespace PhonebookApp.Infrastructure;

public class AppDbContext : DbContext, IUnitOfWork
{
    private readonly IMediator _mediator;

    public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ContactEntityConfiguration());
    }
    
    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEventsAsync(this);

        _ = await base.SaveChangesAsync(cancellationToken);

        return true;
    }
}