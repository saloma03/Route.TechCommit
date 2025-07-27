using Route.TechSummit.Domain.Entities;

namespace Route.TechSummit.Domain.Contracts
{
    public interface ICustomerRepository : IGenericRepository<Customer, int>

    {
        Task<Customer> GetCustomerWithOrdersAsync(int customerId);
        Task<IEnumerable<Customer>> GetAllCustomersWithOrdersAsync();
    }

}
