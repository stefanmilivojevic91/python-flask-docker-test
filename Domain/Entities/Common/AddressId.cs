using System;

namespace Domain.Entities.Common
{
    public record AddressId
    {
        public Guid Value { get; }

        private AddressId(Guid value)
        {
            Value = value;
        }
        public static AddressId Default => new(Guid.NewGuid());
        public static AddressId From(Guid value) => new(value);
    }
}
