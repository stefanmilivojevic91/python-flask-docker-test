using Domain.Entities.Common;
using Domain.Entities.Core;

namespace Domain.Entities.PropertyAggregate
{
    public class Report :
        Entity<ReportId>
    {
        public PropertyId PropertyId { get; }

        public Email Email { get; }
        public ReportDescription Description { get; }
        public bool IsResolved { get; private set; }

        private Report(ReportId id,
            PropertyId propertyId,
            Email email,
            ReportDescription description,
            bool isResolved)
            : base(id)
        {
            PropertyId = propertyId;
            Email = email;
            Description = description;
            IsResolved = isResolved;
        }

        public static Report Create(PropertyId propertyId,
            Email email,
            ReportDescription description)
        {
            return new(ReportId.Default,
                propertyId,
                email,
                description,
                false);
        }

        public void MarkAsDone()
        {
            IsResolved = true;
        }
    }
}
