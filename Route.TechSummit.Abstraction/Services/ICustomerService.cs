using Route.TechSummit.DTOs.CustomerDTOs;
using Route.TechSummit.DTOs.OrderDTOs;

namespace Route.TechSummit.Abstraction.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto customerDto);
        Task<IEnumerable<OrderDto>> GetCustomerOrdersAsync(int customerId);
        Task<CustomerDto> GetCustomerByIdAsync(int customerId);
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task UpdateCustomerAsync(int id, CustomerUpdateDto customerDto);
        Task DeleteCustomerAsync(int id);
    }
}
