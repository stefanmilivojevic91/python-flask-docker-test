namespace Domain.Entities.PropertyAggregate
{
    public record ReportId
    {
        public int Value { get; }

        private ReportId(int value)
        {
            Value = value;
        }

        public static ReportId From(int value) => new(value);
        public static ReportId Default => new(default(int));
    }
}
