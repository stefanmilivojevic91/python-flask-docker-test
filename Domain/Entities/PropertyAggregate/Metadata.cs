using Domain.Entities.Core;

namespace Domain.Entities.PropertyAggregate
{
    public class Metadata :
        Entity<PropertyId>
    {
        public int NumberOfGuests { get; private set; }
        public int? NumberOfBeds { get; private set; }
        public int? NumberOfBedrooms { get; private set; }
        public int? NumberOfBathrooms { get; private set; }
        public bool HasSeaView { get; private set; }
        public bool HasBalcony { get; private set; }
        public bool HasPrivateBathroom { get; private set; }
        public bool HasKitchen { get; private set; }
        public bool HasAirConditioner { get; private set; }
        public bool HasWiFi { get; private set; }
        public bool HasChildBed { get; private set; }
        public bool HasParking { get; private set; }
        public bool IsPetFriendly { get; private set; }
        public bool HasPool { get; private set; }
        public int? Category { get; private set; }

        private Metadata(PropertyId id,
                        int numberOfGuests,
                        int? numberOfBeds,
                        int? numberOfBedrooms,
                        int? numberOfBathrooms,
                        bool hasSeaView,
                        bool hasBalcony,
                        bool hasPrivateBathroom,
                        bool hasKitchen,
                        bool hasAirConditioner,
                        bool hasWiFi,
                        bool hasChildBed,
                        bool hasParking,
                        bool isPetFriendly,
                        bool hasPool,
                        int? category)
            : base(id)
        {
            NumberOfGuests = numberOfGuests;
            NumberOfBeds = numberOfBeds;
            NumberOfBedrooms = numberOfBedrooms;
            NumberOfBathrooms = numberOfBathrooms;
            HasSeaView = hasSeaView;
            HasBalcony = hasBalcony;
            HasPrivateBathroom = hasPrivateBathroom;
            HasKitchen = hasKitchen;
            HasAirConditioner = hasAirConditioner;
            HasWiFi = hasWiFi;
            HasChildBed = hasChildBed;
            HasParking = hasParking;
            IsPetFriendly = isPetFriendly;
            HasPool = hasPool;
            Category = category;
        }

        public static Metadata Create(PropertyId id,
                                      int numberOfGuests,
                                      int? numberOfBeds = default,
                                      int? numberOfBedrooms = default,
                                      int? numberOfBathrooms = default,
                                      bool hasSeaView = default,
                                      bool hasBalcony = default,
                                      bool hasPrivateBathroom = default,
                                      bool hasKitchen = default,
                                      bool hasAirConditioner = default,
                                      bool hasWiFi = default,
                                      bool hasChildBed = default,
                                      bool hasParking = default,
                                      bool isPetFriendly = default,
                                      bool hasPool = default,
                                      int? category = default)
        {
            return new Metadata(id,
                                numberOfGuests,
                                numberOfBeds,
                                numberOfBedrooms,
                                numberOfBathrooms,
                                hasSeaView,
                                hasBalcony,
                                hasPrivateBathroom,
                                hasKitchen,
                                hasAirConditioner,
                                hasWiFi,
                                hasChildBed,
                                hasParking,
                                isPetFriendly,
                                hasPool,
                                category);
        }
    }
}
