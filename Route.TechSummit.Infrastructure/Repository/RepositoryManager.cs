using Route.TechSummit.Domain.Contracts;
using Route.TechSummit.Domain.Entities;
using Route.TechSummit.Infrastructure.Presistence.Data;
using Route.TechSummit.Infrastructure.Presistence.UnitOfWork;
using Route.TechSummit.Infrastructure.Presistence.Repository;
using Route.TechSummit.Infrastructure.Presistence.Repository;

namespace Route.TechSummit.Infrastructure.Repository
{
    internal class RepositoryManager : IRepositoryManager
    {
        private readonly TechSummitDbContext _dbContext;
        private readonly Lazy<IGenericRepository<Product, int>> _productRepository;
        // Add other repositories similarly

        public RepositoryManager(TechSummitDbContext dbContext)
        {
            _dbContext = dbContext;
            _productRepository = new Lazy<IGenericRepository<Product, int>>(() =>
                new GenericRepository<Product, int>(_dbContext));
            // Initialize other repositories
        }

        public IGenericRepository<Product, int> ProductRepository => _productRepository.Value;
        // Implement other repository properties
        public IUnitOfWork UnitOfWork => new UnitOfWork(_dbContext);
    }
}
