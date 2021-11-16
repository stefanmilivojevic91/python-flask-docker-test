using Domain.Contracts.Persistence;
using Domain.Entities.PropertyAggregate;
using Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{
    public class UnitOfWork :
        IApplicationUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction _dbContextTransaction;

        public IRepository<User> Users => new Repository<User>(_context);
        public IRepository<Property> Properties => new Repository<Property>(_context);

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Begin()
        {
            _dbContextTransaction = _context.Database.BeginTransaction();
        }

        public async Task Complete(CancellationToken token = default)
        {
            await _context.SaveChangesAsync(token);
            _dbContextTransaction?.Commit();
        }

        public void Rollback()
        {
            _dbContextTransaction?.Rollback();

            _context.ChangeTracker
                    .Entries()
                    .ToList()
                    .ForEach(entry => entry.Reload());
        }
    }
}
