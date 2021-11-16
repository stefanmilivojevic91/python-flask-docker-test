using Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class FavoriteConfiguration :
        IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            ConfigureStructure(builder);
            ConfigureRelationships(builder);
        }

        private static void ConfigureStructure(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasKey(entry => entry.Id);
            builder.Property(entry => entry.Id)
                   .HasConversion(favoriteIdEntry => favoriteIdEntry.Value, databaseValueEntry => FavoriteId.From(databaseValueEntry));

            builder.Property(entry => entry.UserId);
            builder.HasIndex(entry => entry.UserId);

            builder.Property(entry => entry.PropertyId);
            builder.HasIndex(entry => entry.PropertyId);

            builder.HasIndex(entry => new { entry.UserId, entry.PropertyId }).IsUnique();
        }

        private static void ConfigureRelationships(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasOne(favoriteEntry => favoriteEntry.Property)
                   .WithMany()
                   .HasForeignKey(favoriteEntry => favoriteEntry.PropertyId);
        }
    }
}
