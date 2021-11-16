using Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class RoleConfiguration :
        IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            ConfigureStructure(builder);
            ConfigureData(builder);
        }

        private static void ConfigureStructure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(entry => entry.Id);
            builder.Property(entry => entry.Id)
                   .HasConversion(roleIdEntry => roleIdEntry.Value, databaseValueEntry => RoleId.From(databaseValueEntry));

            builder.Property(entry => entry.Name)
                   .IsRequired();
        }

        private void ConfigureData(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(Role.Values);
        }
    }
}
