namespace Domain.Entities.PropertyAggregate
{
    public record PropertyTitle
    {
        public string Value { get; }

        private PropertyTitle(string value)
        {
            Value = value;
        }
        // Must have max length
        public static PropertyTitle From(string value) => new(value);
    }
}
