using System.Linq;
using System.Reflection;
using Domain.Entities.Core;

namespace Domain.Entities.PropertyAggregate
{
    public class PropertyType :
        Entity<int>
    {
        public string Name { get; }

        private PropertyType(int id, string name)
            : base(id)
        {
            Name = name;
        }

        public static PropertyType Room => new(1, "Room");
        public static PropertyType Studio => new(2, "Studio");
        public static PropertyType Apartment => new(3, "Apartment");
        public static PropertyType House => new(4, "House");

        private static readonly PropertyType[] Values = typeof(PropertyType)
                                                        .GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.GetProperty)
                                                        .Select(propertyInfoEntry => (PropertyType)propertyInfoEntry.GetValue(null))
                                                        .ToArray();

        public static PropertyType Parse(string name)
        {
            return Values.Single(propertyTypeEntry => propertyTypeEntry.Name == name);
        }
    }
}
