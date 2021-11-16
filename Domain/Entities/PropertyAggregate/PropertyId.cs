namespace Domain.Entities.PropertyAggregate
{
    public record PropertyId
    {
        public int Value { get; }

        private PropertyId(int value)
        {
            Value = value;
        }
        
        public static PropertyId From(int value) => new(value);
        public static PropertyId Default => new(default(int));
    }
}
