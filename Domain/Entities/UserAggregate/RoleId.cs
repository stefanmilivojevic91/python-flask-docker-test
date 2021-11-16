namespace Domain.Entities.UserAggregate
{
    public record RoleId
    {
        public int Value { get; }

        private RoleId(int value)
        {
            Value = value;
        }
        public static RoleId From(int value) => new(value);
    }
}
