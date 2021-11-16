using Domain.Entities.PropertyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Core;

namespace Persistence.Configurations
{
    public class PriceConfiguration :
        IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            ConfigureStructure(builder);
        }

        private static void ConfigureStructure(EntityTypeBuilder<Price> builder)
        {
            builder.HasKey(entry => entry.Id);
            builder.Property(entry => entry.Id)
                .HasConversion(propertyIdEntry => propertyIdEntry.Value, databaseValueEntry => PropertyId.From(databaseValueEntry));

            builder.Property(entry => entry.January)
                .IsMoney();

            builder.Property(entry => entry.February)
               .IsMoney();

            builder.Property(entry => entry.March)
               .IsMoney();

            builder.Property(entry => entry.April)
               .IsMoney();

            builder.Property(entry => entry.May)
               .IsMoney();

            builder.Property(entry => entry.June)
               .IsMoney();

            builder.Property(entry => entry.July)
               .IsMoney();

            builder.Property(entry => entry.August)
               .IsMoney();

            builder.Property(entry => entry.September)
               .IsMoney();

            builder.Property(entry => entry.October)
               .IsMoney();

            builder.Property(entry => entry.November)
               .IsMoney();

            builder.Property(entry => entry.December)
               .IsMoney();
        }
    }
}
