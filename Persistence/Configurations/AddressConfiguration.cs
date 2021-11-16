using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AddressConfiguration :
        IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            ConfigureStructure(builder);
        }

        private static void ConfigureStructure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(entry => entry.Id);
            builder.Property(entry => entry.Id)
                   .HasConversion(addressIdEntry => addressIdEntry.Value, databaseValueEntry => AddressId.From(databaseValueEntry));

            builder.Property(entry => entry.Street)
                   .IsRequired();
            
            builder.Property(entry => entry.Number)
                   .IsRequired(); 

            builder.Property(entry => entry.City)
                   .IsRequired();
        }
    }
}
