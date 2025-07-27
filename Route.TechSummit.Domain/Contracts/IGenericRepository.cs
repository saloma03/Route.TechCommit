using Route.TechSummit.Domain.Common;

namespace Route.TechSummit.Domain.Contracts
{
    public interface IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        // 1. Get entity by ID
        Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);

        // 2. Get all entities (with optional filtering/pagination)
        Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        // 3. Add a new entity
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        // 4. Update an existing entity
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        // 5. Delete an entity by ID
        Task DeleteAsync(TKey id, CancellationToken cancellationToken = default);
    }
}