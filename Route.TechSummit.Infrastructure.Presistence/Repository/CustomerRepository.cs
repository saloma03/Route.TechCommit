using Route.TechSummit.Domain.Contracts;
using Route.TechSummit.Domain.Entities;
using Route.TechSummit.Infrastructure.Presistence.Data;

namespace Route.TechSummit.Infrastructure.Presistence.Repository
{
    public class CustomerRepository : GenericRepository<Customer, int>, ICustomerRepository
    {
        private readonly TechSummitDbContext _dbContext;  // Corrected name here

        public CustomerRepository(TechSummitDbContext dbContext) : base(dbContext)  // Corrected name here
        {
            _dbContext = dbContext;  // Corrected name here
        }

        public async Task<Customer> GetCustomerWithOrdersAsync(int customerId)
        {
            return await _dbContext.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderItems)
                .FirstOrDefaultAsync(c => c.Id == customerId);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersWithOrdersAsync()
        {
            return await _dbContext.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderItems)
                .ToListAsync();
        }
    }
}
