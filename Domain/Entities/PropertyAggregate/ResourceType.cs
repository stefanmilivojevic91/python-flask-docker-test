using Domain.Entities.Core;
using System.Linq;
using System.Reflection;

namespace Domain.Entities.PropertyAggregate
{
    public class ResourceType :
        Entity<int>
    {
        public string Name { get; }

        private ResourceType(int id, string name)
            : base(id)
        {
            Name = name;
        }

        public static ResourceType PropertyOriginalImage => new(1, "PropertyOriginalImage");
        public static ResourceType PropertyThumbnailImage => new(2, "PropertyThumbnailImage");
        public static ResourceType PropertyMapThumbnailImage => new(3, "PropertyMapThumbnailImage");

        private static readonly ResourceType[] Values = typeof(ResourceType)
            .GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.GetProperty)
            .Select(resourceEntry => (ResourceType)resourceEntry.GetValue(null))
            .ToArray();

        public static ResourceType Parse(string name)
        {
            return Values.Single(propertyStatusEntry => propertyStatusEntry.Name == name);
        }
    }
}
