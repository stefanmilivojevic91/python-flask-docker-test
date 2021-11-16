using Domain.Entities.Core;
using System;
using Domain.Entities.Common;

namespace Domain.Entities.UserAggregate
{
    public class Profile :
        Entity<UserId>
    {
        public DateTime Created { get; private set; }
        public DateTime Modified { get; private set; }
        //todo phone num as value object
        public string PhoneNumber1 { get; private set; }
        public string PhoneNumber2 { get; private set; }
        public string PhoneNumber3 { get; private set; }

        public AddressId AddressId { get; private set; }
        public Address Address { get; private set; }

        private Profile(UserId id, string phoneNumber1, string phoneNumber2, string phoneNumber3, AddressId addressId)
            : base(id)
        {
            Created = DateTime.UtcNow;
            Modified = default;
            PhoneNumber1 = phoneNumber1;
            PhoneNumber2 = phoneNumber2;
            PhoneNumber3 = phoneNumber3;
            AddressId = addressId;
        }

        public Profile Create(UserId id,
                              string phoneNumber1,
                              string phoneNumber2,
                              string phoneNumber3,
                              AddressId addressId)
        {
            return new Profile(id, phoneNumber1, phoneNumber2, phoneNumber3, addressId);
        }

        public void SetAddress(Address address)
        {
            Address = address;
        }

        public void UpdateAddress(Address address)
        {
            Address.Update(address);
        }
    }
}
