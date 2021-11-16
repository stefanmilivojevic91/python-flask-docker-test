using System.Linq;
using System.Reflection;
using Domain.Entities.Core;

namespace Domain.Entities.UserAggregate
{
    public class Role :
        Entity<RoleId>
    {
        public string Name { get; }
        
        private Role(RoleId id, string name)
            : base(id)
        {
            Name = name;
        }

        public static Role User => new(RoleId.From(1), "User");
        public static Role Employee => new(RoleId.From(2), "Employee");
        public static Role Admin => new(RoleId.From(3), "Admin");

        public static readonly Role[] Values = typeof(Role)
                                                .GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.GetProperty)
                                                .Select(propertyInfoEntry => (Role)propertyInfoEntry.GetValue(null))
                                                .ToArray();
    }
}
