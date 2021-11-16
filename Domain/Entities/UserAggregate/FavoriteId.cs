namespace Domain.Entities.UserAggregate
{
    public record FavoriteId
    {
        public long Value { get; }

        private FavoriteId(long value)
        {
            Value = value;
        }
        public static FavoriteId Default => new(default(long));
        public static FavoriteId From(long value) => new(value);
    }
}
