namespace Domain.Entities.PropertyAggregate
{
    public record ReportDescription
    {
        public string Value { get; }

        private ReportDescription(string value)
        {
            Value = value;
        }
        // Must have max length
        public static ReportDescription From(string value) => new(value);
    }
}
