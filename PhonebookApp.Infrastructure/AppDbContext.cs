using MediatR;
using Microsoft.EntityFrameworkCore;
using PhonebookApp.Infrastructure.EntityConfigurations;
using PhonebookApp.Infrastructure.Extensions;

namespace PhonebookApp.Infrastructure;

public class AppDbContext : DbContext
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

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        await _mediator.DispatchDomainEventsAsync(this);
        
        return result;
    }
}