using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Route.TechSummit.Abstraction.Services;
using Route.TechSummit.Application.DTOs.CustomerDTOs;
using Route.TechSummit.Application.DTOs.OrderDTOs;
using Route.TechSummit.Infrastructure.Repository;
namespace Route.TechSummit.Application.Service.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CustomerService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto customerDto)
        {
            var customer = _mapper.Map<Domain.Entities.Customer>(customerDto);
            await _repositoryManager.CustomerRepository.AddAsync(customer);
            await _repositoryManager.UnitOfWork.CompleteAsync();
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<IEnumerable<OrderDto>> GetCustomerOrdersAsync(int customerId)
        {
            var orders = await _repositoryManager.OrderRepository.GetOrdersByCustomerIdAsync(customerId);
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _repositoryManager.CustomerRepository.GetByIdAsync(customerId);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _repositoryManager.CustomerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task UpdateCustomerAsync(int id, CustomerUpdateDto customerDto)
        {
            var customer = await _repositoryManager.CustomerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                // Handle not found exception
                return;
            }
            _mapper.Map(customerDto, customer);
            await _repositoryManager.CustomerRepository.UpdateAsync(customer);
            await _repositoryManager.UnitOfWork.CompleteAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _repositoryManager.CustomerRepository.DeleteAsync(id);
            await _repositoryManager.UnitOfWork.CompleteAsync();
        }
    }
}
