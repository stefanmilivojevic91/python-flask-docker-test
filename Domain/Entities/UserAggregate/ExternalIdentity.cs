using System;
using Domain.Entities.Core;

namespace Domain.Entities.UserAggregate
{
    public class ExternalIdentity :
        Entity<UserId>
    {
        public Guid IdpId { get; private set; }
        
        private ExternalIdentity(UserId id,Guid idpId)
            : base(id)
        {
            IdpId = idpId;
        }

        public static ExternalIdentity Create(UserId id, Guid idpId)
        {
            return new ExternalIdentity(id, idpId);
        }

        public void SetIdentityProviderId(Guid idpId)
        {
            IdpId = idpId;
        }
    }
}
