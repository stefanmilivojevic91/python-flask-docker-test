using Domain.Entities.PropertyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class PropertyConfiguration :
        IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            ConfigureStructure(builder);
            ConfigureRelationships(builder);
        }

        private static void ConfigureStructure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(entry => entry.Id);
            builder.Property(entry => entry.Id)
                .HasConversion(propertyIdEntry => propertyIdEntry.Value, databaseValueEntry => PropertyId.From(databaseValueEntry));

            builder.Property(entry => entry.Title)                
                .HasConversion(propertyTitleEntry => propertyTitleEntry.Value, databaseValueEntry => PropertyTitle.From(databaseValueEntry))
                .IsRequired();

            builder.Property(entry => entry.Description)
                .HasConversion(propertyDescriptionEntry => propertyDescriptionEntry.Value, databaseValueEntry => PropertyDescription.From(databaseValueEntry))
                .IsRequired();

            builder.Property(entry => entry.Slug)
                .HasConversion(propertySlugEntry => propertySlugEntry.Value, databaseValueEntry => PropertySlug.From(databaseValueEntry))
                .IsRequired();

            builder.Property(entry => entry.Status)
                .HasConversion(propertyStatusEntry => propertyStatusEntry.Name, databaseValueEntry => PropertyStatus.Parse(databaseValueEntry))
                .IsRequired();

            builder.Ignore(entry => entry.Location);
            builder.Ignore(entry => entry.MinStay);
            builder.Ignore(entry => entry.ViewCounter);
            builder.Ignore(entry => entry.TemporaryViewCounter);
        }

        private static void ConfigureRelationships(EntityTypeBuilder<Property> builder)
        {
            builder.HasMany(entry => entry.Reports)
                   .WithOne()
                   .HasForeignKey(reportEntry => reportEntry.PropertyId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Navigation(entry => entry.Reports);

            builder.HasMany(entry => entry.Resources)
                   .WithOne()
                   .HasForeignKey(resourceEntry => resourceEntry.PropertyId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Navigation(entry => entry.Resources);

            builder.HasMany(entry => entry.Reservations)
                   .WithOne()
                   .HasForeignKey(reservationEntry => reservationEntry.PropertyId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Navigation(entry => entry.Reservations);

            builder.HasOne(entry => entry.Price)
                   .WithOne()
                   .HasForeignKey<Price>(priceEntry => priceEntry.Id)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Navigation(entry => entry.Price);

            builder.HasOne(entry => entry.Metadata)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey<Metadata>(metadataEntry => metadataEntry.Id)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Navigation(entry => entry.Metadata);
            
            builder.HasOne(entry => entry.Owner)
                   .WithMany()
                   .IsRequired()
                   .HasForeignKey(propertyEntry => propertyEntry.OwnerId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.Navigation(entry => entry.Owner);
            
            builder.HasOne(entry => entry.Address)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey<Property>(propertyEntry => propertyEntry.AddressId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Navigation(entry => entry.Address);
        }
    }
}
