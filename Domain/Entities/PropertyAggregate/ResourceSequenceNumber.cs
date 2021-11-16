using System;

namespace Domain.Entities.PropertyAggregate
{
    public record ResourceSequenceNumber
    {
        public int Value { get; }

        private ResourceSequenceNumber(int value)
        {
            Value = value;
        }

        public static ResourceSequenceNumber From(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            return new ResourceSequenceNumber(value);
        }
    }
}
