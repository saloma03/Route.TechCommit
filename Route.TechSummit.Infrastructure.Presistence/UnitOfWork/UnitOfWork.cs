using System.Collections.Concurrent;
using Route.TechSummit.Domain.Common;
using Route.TechSummit.Domain.Contracts;
using Route.TechSummit.Infrastructure.Presistence.Data;
using Route.TechSummit.Infrastructure.Presistence.Repository;

namespace Route.TechSummit.Infrastructure.Presistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechSummitDbContext _dbContext;
        private readonly ConcurrentDictionary<Type, object> _repositories;

        public UnitOfWork(TechSummitDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _repositories = new ConcurrentDictionary<Type, object>();
        }

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return (IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(
                typeof(TEntity),
                _ => new GenericRepository<TEntity, TKey>(_dbContext)
            );
        }

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
            _repositories.Clear();
        }

    }
}