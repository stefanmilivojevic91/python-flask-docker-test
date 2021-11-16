using Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UserRoleConfiguration :
        IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            ConfigureStructure(builder);
            ConfigureRelationships(builder);
        }

        private static void ConfigureStructure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(entry => entry.Id);
            builder.Property(entry => entry.Id)
                   .HasConversion(userRoleIdEntry => userRoleIdEntry.Value, databaseValueEntry => UserRoleId.From(databaseValueEntry));

            builder.Property(entry => entry.UserId);
            builder.HasIndex(entry => entry.UserId);

            builder.Property(entry => entry.RoleId);
            builder.HasIndex(entry => entry.RoleId);

            builder.HasIndex(entry => new { entry.UserId, entry.RoleId }).IsUnique();
        }

        private static void ConfigureRelationships(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(userRoleEntry => userRoleEntry.Role)
                   .WithMany()
                   .HasForeignKey(userRoleEntry => userRoleEntry.RoleId);
        }
    }
}
