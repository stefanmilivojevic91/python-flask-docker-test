using System;

namespace Domain.Entities.PropertyAggregate
{
    public record ResourceId
    {
        public Guid Value { get; }

        private ResourceId(Guid value)
        {
            Value = value;
        }

        public static ResourceId From(Guid value) => new(value);

        public static ResourceId Default => new(Guid.NewGuid());
    }
}
