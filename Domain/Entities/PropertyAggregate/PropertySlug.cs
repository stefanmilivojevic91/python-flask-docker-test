namespace Domain.Entities.PropertyAggregate
{
    public record PropertySlug
    {
        public string Value { get; }

        private PropertySlug(string value)
        {
            Value = value;
        }
        // Make value object for AdSlug and make slug generator
        public static PropertySlug From(string value) => new(value); 
    }
}
