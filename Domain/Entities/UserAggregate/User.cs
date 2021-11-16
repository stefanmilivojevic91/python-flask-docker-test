using System;
using Domain.Entities.Core;
using System.Collections.Generic;
using Domain.Entities.Common;

namespace Domain.Entities.UserAggregate
{
    public class User :
        Entity<UserId>,
        IAggregateRoot
    {
        public Name Name { get; private set; }
        public Email Email { get; private set; }

        private Profile _profile;
        public virtual Profile Profile => _profile;

        private readonly ExternalIdentity _externalIdentity;
        public virtual ExternalIdentity ExternalIdentity => _externalIdentity;

        private List<UserRole> _userRoles;
        public virtual IReadOnlyCollection<UserRole> UserRoles => _userRoles.AsReadOnly();

        private List<Favorite> _favorites;
        public virtual IReadOnlyCollection<Favorite> Favorites => _favorites.AsReadOnly();

        private User(UserId id, Name name, Email email)
            : base(id)
        {
            Name = name;
            Email = email;
        }
        
        public void SetProfile(Profile profile)
        {
            _profile = profile;
        }

        public void AddRole(Role role)
        {
            var userRole = UserRole.Create(role.Id, Id);

            if (_userRoles is null)
            {
                _userRoles = new List<UserRole> { userRole };
            }
            else
            {
                _userRoles.Add(userRole);
            }
        }

        public void SetExternalIdentity(Guid idpId)
        {
            _externalIdentity.SetIdentityProviderId(idpId);
        }
        
    }
}
