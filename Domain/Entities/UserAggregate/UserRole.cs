using Domain.Entities.Core;

namespace Domain.Entities.UserAggregate
{
    public class UserRole :
        Entity<UserRoleId>
    {
        public UserId UserId { get; }

        public RoleId RoleId { get; }
        public Role Role { get; private set; }

        private UserRole(UserRoleId id, UserId userId, RoleId roleId) :
            base(id)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public static UserRole Create(RoleId roleId, UserId userId)
        {
            return new UserRole(UserRoleId.Default, userId, roleId);
        }
    }
}
