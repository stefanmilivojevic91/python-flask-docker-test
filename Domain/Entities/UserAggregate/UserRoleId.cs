namespace Domain.Entities.UserAggregate
{
    public record UserRoleId
    {
        public int Value { get; }

        private UserRoleId(int value)
        {
            Value = value;
        }
        public static UserRoleId Default => new(default(int));
        public static UserRoleId From(int value) => new(value);
    }
}
