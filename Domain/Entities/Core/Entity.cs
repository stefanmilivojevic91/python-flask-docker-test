namespace Domain.Entities.Core
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; }
        public Events Events { get; }

        protected Entity()
        {
            Events = new Events();
        }

        protected Entity(TKey id)
            : this()
        {
            Id = id;
        }
    }
}
