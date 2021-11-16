using System.Collections.Generic;

namespace Domain.Entities.Core
{
    public class Events
    {
        private List<IEvent> _data;
        public IReadOnlyCollection<IEvent> Data => _data.AsReadOnly();

        internal Events()
        {
            _data = new List<IEvent>();
        }

        public void Raise(IEvent entry)
        {
            _data.Add(entry);
        }

        public void Clear()
        {
            _data.Clear();
        }
    }
}
