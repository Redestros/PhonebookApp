using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhonebookApp.Core.Aggregates.ContactAggregate;

namespace PhonebookApp.Infrastructure.EntityConfigurations;

public class ContactEntityConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Phone).IsUnique();

        builder.Ignore(x => x.DomainEvents);
    }
}