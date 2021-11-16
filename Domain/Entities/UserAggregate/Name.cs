namespace Domain.Entities.UserAggregate
{
    public record Name
    {
        public string First { get; }
        public string Last { get; }

        private Name(string first, string last)
        {
            First = first;
            Last = last;
        }
        public static Name Create(string first, string last)
        {
            return new Name(first, last);
        }

        public static implicit operator string(Name name) => $"{name.First} {name.Last}";
    }
}
