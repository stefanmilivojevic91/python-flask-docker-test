using Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ExternalIdentityConfiguration :
        IEntityTypeConfiguration<ExternalIdentity>
    {
        public void Configure(EntityTypeBuilder<ExternalIdentity> builder)
        {
            ConfigureStructure(builder);
        }

        private static void ConfigureStructure(EntityTypeBuilder<ExternalIdentity> builder)
        {
            builder.HasKey(entry => entry.Id);
            builder.Property(entry => entry.Id)
                   .HasConversion(userIdEntry => userIdEntry.Value, databaseValueEntry => UserId.From(databaseValueEntry));

            builder.Property(entry => entry.IdpId)
                   .IsRequired();

            builder.HasIndex(entry => entry.IdpId)
                   .IsUnique();
        }
    }
}
