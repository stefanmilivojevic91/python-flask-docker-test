using Domain.Entities.Core;

namespace Domain.Entities.Common
{
    public class Address :
        Entity<AddressId>
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Area { get; private set; }
        public string County { get; private set; }
        public string Country { get; private set; }

        private Address(AddressId id,
                        string street,
                        string number,
                        string city,
                        string postalCode,
                        string area,
                        string county,
                        string country)
            : base(id)
        {
            Street = street;
            Number = number;
            City = city;
            PostalCode = postalCode;
            Area = area;
            County = county;
            Country = country;
        }

        public static Address Create(string street,
                                     string number,
                                     string city,
                                     string postalCode,
                                     string area,
                                     string county,
                                     string country)
        {
            return new Address(AddressId.Default, street, number, city, postalCode, area, county, country);
        }

        public void Update(Address address)
        {
            Street = address.Street;
            Number = address.Number;
            City = address.City;
            PostalCode = address.PostalCode;
            Area = address.Area;
            County = address.County;
            Country = address.Country;
        }
    }
}
