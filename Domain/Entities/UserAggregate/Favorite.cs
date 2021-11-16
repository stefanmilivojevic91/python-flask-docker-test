using Domain.Entities.Common;
using Domain.Entities.Core;
using Domain.Entities.PropertyAggregate;

namespace Domain.Entities.UserAggregate
{
    public class Favorite :
        Entity<FavoriteId>
    {
        public UserId UserId { get; }
        public PropertyId PropertyId { get; }
        public Note Note { get; }
        public virtual Property Property { get; }

        private Favorite(FavoriteId id,
            UserId userId,
            PropertyId propertyId,
            Note note)
            : base(id)
        {
            UserId = userId;
            PropertyId = propertyId;
            Note = note;
        }

        public static Favorite Create(UserId userId,
            PropertyId propertyId,
            Note note = default)
        {
            return new(FavoriteId.Default,
                userId,
                propertyId,
                note);
        }
    }
}
