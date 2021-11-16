namespace Domain.Entities.PropertyAggregate
{
    public record PropertyDescription
    {
        public string Value { get; }

        private PropertyDescription(string value)
        {
            Value = value;
        }
        // Must have max length
        public static PropertyDescription From(string value) => new(value); 
    }
}
