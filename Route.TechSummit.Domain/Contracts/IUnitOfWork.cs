using Route.TechSummit.Domain.Common;
using Route.TechSummit.Domain.Contracts;

namespace Route.TechSummit.Infrastructure.Presistence.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>;
        Task<int> CompleteAsync();



    }
}
