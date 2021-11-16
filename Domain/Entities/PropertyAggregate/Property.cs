using Domain.Entities.Core;
using System;
using System.Collections.Generic;
using Domain.Entities.Common;
using Domain.Entities.UserAggregate;

namespace Domain.Entities.PropertyAggregate
{
    public class Property :
        Entity<PropertyId>,
        IAggregateRoot
    {
        public UserId OwnerId { get; }
        public AddressId AddressId { get; }

        public PropertyTitle Title { get; private set; } 
        public PropertyDescription Description { get; private set; }
        public PropertyType Type { get; private set; }
        public Location Location { get; private set; }
        public PropertySlug Slug { get; private set; } 
        public PropertyStatus Status { get; init; }    
        public int MinStay { get; }
        public int ViewCounter { get; private set; } 
        public int TemporaryViewCounter { get; private set; }
        public bool IsAddressHidden { get; private set; }
        
        public DateTime Created { get; set; }
        public DateTime? ValidUntil { get; set; } 

        private List<Report> _reports;
        public IReadOnlyCollection<Report> Reports => _reports.AsReadOnly();

        private List<Resource> _resources;
        public IReadOnlyCollection<Resource> Resources => _resources.AsReadOnly();

        private List<Reservation> _reservations;
        public IReadOnlyCollection<Reservation> Reservations => _reservations.AsReadOnly();

        private readonly Price _price;
        public virtual Price Price => _price;
        
        private readonly Metadata _metadata;
        public virtual Metadata Metadata => _metadata;

        private readonly User _owner;
        public virtual User Owner => _owner;

        private readonly Address _address;
        public virtual Address Address => _address;

        private Property(PropertyId id,
            PropertyTitle title,
            PropertyDescription description,
            PropertySlug slug,
            PropertyStatus status)
            : base(id)
        {
            Title = title;
            Description = description;
            Status = status;
            Slug = slug;
            ViewCounter = TemporaryViewCounter = 0;
            Created = DateTime.UtcNow;
            ValidUntil = default;
            MinStay = default;
        }

        public static Property Create()
        {
            // PropertyStatus
            // preset on initial creation
            // Active => Blocked => Deleted => Inactive

            // PaymentStatus
            // Paid => Unpaid

            var id = PropertyId.Default;
            var title = PropertyTitle.From("");
            var description = PropertyDescription.From("");
            var defaultStatus = PropertyStatus.Active;
            var location = Location.FromCoordinates(1, 1);
            var slug = PropertySlug.From("");
            var address = "";

            return new Property(id, title, description, slug, defaultStatus);
        }
    }
}
