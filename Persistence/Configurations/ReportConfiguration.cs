using Domain.Entities.Common;
using Domain.Entities.PropertyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Core;

namespace Persistence.Configurations
{
    public class ReportConfiguration :
        IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            ConfigureStructure(builder);
        }

        private static void ConfigureStructure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(entry => entry.Id);
            builder.Property(entry => entry.Id)
                .HasConversion(reportIdEntry => reportIdEntry.Value, databaseValueEntry => ReportId.From(databaseValueEntry));

            builder.Property(entry => entry.Email)
                   .IsEmail()
                   .IsRequired();

            builder.Property(entry => entry.Description)
                .HasConversion(propertyDescriptionEntry => propertyDescriptionEntry.Value, databaseValueEntry => ReportDescription.From(databaseValueEntry))
                .IsRequired();

            builder.Property(entry => entry.IsResolved)
                .IsRequired();
        }
    }
}
