using System;

namespace Domain.Entities.UserAggregate
{
    public record UserId
    {
        public Guid Value { get; }

        private UserId(Guid value)
        {
            Value = value;
        }
        public static UserId Default => new(Guid.NewGuid());
        public static UserId From(Guid value) => new(value);
    }
}
