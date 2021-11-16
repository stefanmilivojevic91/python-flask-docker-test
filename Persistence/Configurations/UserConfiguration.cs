using Domain.Entities.Common;
using Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Core;

namespace Persistence.Configurations
{
    public class UserConfiguration :
        IEntityTypeConfiguration<User>
    {
        private const string FIRST_NAME_COLUMN_NAME = "FirstName";
        private const string LAST_NAME_COLUMN_NAME = "LastName";

        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureStructure(builder);
            ConfigureRelationships(builder);
        }

        private static void ConfigureStructure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(entry => entry.Id);
            builder.Property(entry => entry.Id)
                   .HasConversion(userIdEntry => userIdEntry.Value,
                                  databaseValueEntry => UserId.From(databaseValueEntry));

            builder.OwnsOne(entry => entry.Name, ownedEntityBuilderEntry =>
            {
                ownedEntityBuilderEntry.Property(entity => entity.First)
                    .HasColumnName(FIRST_NAME_COLUMN_NAME)
                    .IsRequired();
                ownedEntityBuilderEntry.Property(entity => entity.Last)
                    .HasColumnName(LAST_NAME_COLUMN_NAME)
                    .IsRequired();
            });

            builder.Property(entry => entry.Email)
                   .IsEmail()
                   .IsRequired();

            builder.HasIndex(entry => entry.Email)
                   .IsUnique();
        }

        private static void ConfigureRelationships(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(entry => entry.Profile)
                   .WithOne()
                   .HasForeignKey<Profile>(profileEntry => profileEntry.Id)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Navigation(entry => entry.Profile);

            builder.HasOne(entry => entry.ExternalIdentity)
                   .WithOne()
                   .HasForeignKey<ExternalIdentity>(externalIdentityEntry => externalIdentityEntry.Id)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Navigation(entry => entry.ExternalIdentity);

            builder.HasMany(entry => entry.UserRoles)
                   .WithOne()
                   .HasForeignKey(userRoleEntry => userRoleEntry.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Navigation(entry => entry.UserRoles);

            builder.HasMany(entry => entry.Favorites)
                   .WithOne()
                   .HasForeignKey(favoriteEntry => favoriteEntry.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Navigation(entry => entry.Favorites);
        }
    }
}
