using Domain.Entities.Core;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Contracts.Persistence
{
    public interface IRepository<TRoot>
        where TRoot : class, IAggregateRoot
    {
        Task<TRoot> Find(Expression<Func<TRoot, bool>> predicate, CancellationToken token = default);
        Task<bool> Exist(Expression<Func<TRoot, bool>> predicate, CancellationToken token = default);
        Task Create(TRoot entity, CancellationToken token);
        void Delete(TRoot entity);
    }
}
