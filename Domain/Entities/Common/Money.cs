namespace Domain.Entities.Common
{
    public record Money
    {
        public decimal Value { get; }

        private Money(decimal value)
        {
            Value = value;
        }

        public static Money From(decimal value) => new(value);
    }
}