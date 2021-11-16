using Domain.Entities.Common;
using Domain.Entities.PropertyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Core
{
    internal static class ConfigurationExtensions
    {
        internal static PropertyBuilder<Email> IsEmail(this PropertyBuilder<Email> builder)
        {
            builder.HasConversion(valueObjectEntry => valueObjectEntry.Value.ToLowerInvariant(),
                                  databaseValueEntry => Email.From(databaseValueEntry))
                   .HasMaxLength(300);
            return builder;
        }
        
        internal static PropertyBuilder<Money> IsMoney(this PropertyBuilder<Money> builder)
        {
            builder.HasConversion(valueObjectEntry => valueObjectEntry.Value,
                                  databaseValueEntry => Money.From(databaseValueEntry))
                   .HasColumnType("money");
            return builder;
        }
    }
}
