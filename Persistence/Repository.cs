using Domain.Contracts.Persistence;
using Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{
    public class Repository<TRoot> :
        IRepository<TRoot>
        where TRoot : class, IAggregateRoot
    {
        protected DbSet<TRoot> _entityContext;
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _entityContext = context.Set<TRoot>();
            _context = context;
        }

        public Task<TRoot> Find(Expression<Func<TRoot, bool>> predicate,
            CancellationToken token = default)
        {
            return _entityContext.Where(predicate)
                .SingleOrDefaultAsync(token);
        }

        public Task<bool> Exist(Expression<Func<TRoot, bool>> predicate, CancellationToken token = default)
        {
            return _entityContext.AnyAsync(predicate, token);
        }

        public Task Create(TRoot entity, CancellationToken token)
        {
            return _entityContext.AddAsync(entity, token).AsTask();
        }

        public void Delete(TRoot entity)
        {
            _entityContext.Remove(entity);
        }
    }
}
