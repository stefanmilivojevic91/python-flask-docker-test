namespace Domain.Entities.Common
{
    public record Note
    {
        public string Value { get; }

        private Note(string value)
        {
            Value = value;
        }

        public static Note From(string value) => new(value);
    }
}
