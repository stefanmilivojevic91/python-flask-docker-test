using Domain.Entities.Core;
using System;

namespace Domain.Entities.PropertyAggregate
{
    public class Reservation :
        Entity<ReservationId>
    {
        public PropertyId PropertyId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        private Reservation(ReservationId id,
            PropertyId propertyId,
            DateTime from,
            DateTime to)
            : base(id)
        {
            PropertyId = propertyId;
            From = from;
            To = to;
        }

        public static Reservation Create(PropertyId propertyId,
            DateTime from,
            DateTime to)
        {
            return new(ReservationId.Default, propertyId, from, to);
        }
    }
}
