using Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ProfileConfiguration :
        IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            ConfigureStructure(builder);
            ConfigureRelationships(builder);
        }

        private static void ConfigureStructure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(entry => entry.Id);
            builder.Property(entry => entry.Id)
                   .HasConversion(userIdEntry => userIdEntry.Value, databaseValueEntry => UserId.From(databaseValueEntry));

            builder.Property(entry => entry.Created)
                   .IsRequired();
            
            builder.Property(entry => entry.PhoneNumber1)
                   .IsRequired();
        }

        private static void ConfigureRelationships(EntityTypeBuilder<Profile> builder)
        {
            builder.HasOne(entry => entry.Address)
                   .WithOne()
                   .IsRequired()
                   .HasForeignKey<Profile>(entry => entry.AddressId);
            builder.Navigation(entry => entry.Address);
        }
    }
}
