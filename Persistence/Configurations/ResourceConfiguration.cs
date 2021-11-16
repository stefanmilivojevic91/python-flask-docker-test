using Domain.Entities.PropertyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Configurations
{
    public class ResourceConfiguration :
        IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            ConfigureStructure(builder);
            ConfigureRelationships(builder);
        }

        private static void ConfigureStructure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(entry => entry.Id);
            builder.Property(entry => entry.Id)
                .HasConversion(resourceIdEntry => resourceIdEntry.Value, databaseValueEntry => ResourceId.From(databaseValueEntry));

            builder.Property(entry => entry.ParentId)
                .HasConversion(resourceIdEntry => resourceIdEntry.Value, databaseValueEntry => ResourceId.From(databaseValueEntry));

            builder.Property(entry => entry.Type)
                .HasConversion(resourceTypeEntry => resourceTypeEntry.Name, databaseValueEntry => ResourceType.Parse(databaseValueEntry))
                .IsRequired();

            builder.Property(entry => entry.Path)
                .HasConversion(uriEntry => uriEntry.AbsolutePath, databaseValueEntry => new Uri(databaseValueEntry))
                .IsRequired();

            builder.Property(entry => entry.IsCover)
                .IsRequired();

            builder.Property(entry => entry.Sequence)
                .HasConversion(sequenceNumberEntry => sequenceNumberEntry.Value, databaseValueEntry => ResourceSequenceNumber.From(databaseValueEntry))
                .IsRequired();
        }

        private static void ConfigureRelationships(EntityTypeBuilder<Resource> builder)
        {
            builder.HasMany(entry => entry.Children)
                   .WithOne()
                   .IsRequired(false)
                   .HasForeignKey(resourceEntry => resourceEntry.ParentId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Navigation(entry => entry.Children);
        }
    }
}
