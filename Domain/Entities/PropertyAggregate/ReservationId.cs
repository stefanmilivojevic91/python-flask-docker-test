namespace Domain.Entities.PropertyAggregate
{
    public record ReservationId
    {
        public int Value { get; }

        private ReservationId(int value)
        {
            Value = value;
        }

        public static ReservationId From(int value) => new(value);
        public static ReservationId Default => new(default(int));
    }
}
