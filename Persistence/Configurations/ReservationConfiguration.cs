using Domain.Entities.Common;
using Domain.Entities.PropertyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Configurations.Core;

namespace Persistence.Configurations
{
    public class ReservationConfiguration :
        IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            ConfigureStructure(builder);
        }

        private static void ConfigureStructure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(entry => entry.Id);
            builder.Property(entry => entry.Id)
                .HasConversion(reservationIdEntry => reservationIdEntry.Value, databaseValueEntry => ReservationId.From(databaseValueEntry));

            builder.Property(entry => entry.PropertyId)
                   .IsRequired();

            builder.Property(entry => entry.From)
                .IsRequired();

            builder.Property(entry => entry.To)
                .IsRequired();
        }
    }
}
