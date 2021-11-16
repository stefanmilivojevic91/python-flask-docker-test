using Domain.Entities.PropertyAggregate;
using Xunit;

namespace Domain.Unit
{
    public class Runner
    {
        [Fact]
        public void Init()
        {
            var statuses = PropertyStatus.Parse("Active1");
        }
    }
}
