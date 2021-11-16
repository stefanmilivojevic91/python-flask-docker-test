using Domain.Entities.PropertyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class MetadataConfiguration :
        IEntityTypeConfiguration<Metadata>
    {
        public void Configure(EntityTypeBuilder<Metadata> builder)
        {
            ConfigureStructure(builder);
        }

        private static void ConfigureStructure(EntityTypeBuilder<Metadata> builder)
        {
            builder.HasKey(entry => entry.Id);
            builder.Property(entry => entry.Id)
                   .HasConversion(propertyIdEntry => propertyIdEntry.Value, databaseValueEntry => PropertyId.From(databaseValueEntry));

            builder.Property(entry => entry.NumberOfGuests)
                   .IsRequired();
        }
    }
}
