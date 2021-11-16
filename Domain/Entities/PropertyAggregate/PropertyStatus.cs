using Domain.Entities.Core;
using System.Linq;
using System.Reflection;

namespace Domain.Entities.PropertyAggregate
{
    public class PropertyStatus :
        Entity<int>
    {
        public string Name { get; }

        private PropertyStatus(int id, string name)
            : base(id)
        {
            Name = name;
        }

        public static PropertyStatus Active => new(1, "Active");
        public static PropertyStatus Blocked => new(2, "Blocked");
        public static PropertyStatus Deleted => new(3, "Deleted");
        public static PropertyStatus Inactive => new(4, "Inactive");

        private static readonly PropertyStatus[] Values = typeof(PropertyStatus)
            .GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.GetProperty)
            .Select(propertyInfoEntry => (PropertyStatus)propertyInfoEntry.GetValue(null))
            .ToArray();

        public static PropertyStatus Parse(string name)
        {
            return Values.Single(propertyStatusEntry => propertyStatusEntry.Name == name);
        }
    }
}
