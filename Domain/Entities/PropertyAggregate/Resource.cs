using Domain.Entities.Core;
using System;
using System.Collections.Generic;

namespace Domain.Entities.PropertyAggregate
{
    public class Resource :
        Entity<ResourceId>
    {
        public ResourceId ParentId { get; }
        public PropertyId PropertyId { get; }
        
        public ResourceType Type { get; }
        public Uri Path { get; }
        public bool IsCover { get; }
        public ResourceSequenceNumber Sequence { get; }

        private readonly List<Resource> _children;
        public IReadOnlyCollection<Resource> Children => _children.AsReadOnly();

        private Resource(ResourceId id,
            ResourceId parentId,
            PropertyId propertyId,
            ResourceType type,
            Uri path,
            bool isCover,
            ResourceSequenceNumber sequence)
            : base(id)
        {
            ParentId = parentId;
            PropertyId = propertyId;
            Type = type;
            Path = path;
            IsCover = isCover;
            Sequence = sequence;
        }

        public static Resource Create(PropertyId propertyId,
            ResourceType type,
            Uri path,
            bool isCover,
            ResourceSequenceNumber sequence)
        {
            return new(ResourceId.Default,
                default,
                propertyId,
                type,
                path,
                isCover,
                sequence);
        }
    }
}
