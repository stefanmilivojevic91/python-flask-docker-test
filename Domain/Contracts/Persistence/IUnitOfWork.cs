using Domain.Entities.PropertyAggregate;
using Domain.Entities.UserAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Contracts.Persistence
{
    public interface IApplicationUnitOfWork :
        IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<Property> Properties { get; }
    }

    public interface IUnitOfWork
    {
        void Begin();
        void Rollback();
        Task Complete(CancellationToken token = default);
    }
}
