using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Route.TechSummit.Abstraction.Services;
using Route.TechSummit.Application.DTOs.CustomerDTOs;
using Route.TechSummit.Controllers.Controllers.Base;

namespace Route.TechSummit.Controllers
{
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateDto customerDto)
        {
            var customer = await _customerService.CreateCustomerAsync(customerDto);
            return HandleResult(customer, System.Net.HttpStatusCode.Created);
        }

        [HttpGet("{customerId}/orders")]
        public async Task<IActionResult> GetCustomerOrders(int customerId)
        {
            var orders = await _customerService.GetCustomerOrdersAsync(customerId);
            return HandleResult(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            return HandleResult(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return HandleResult(customers);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerUpdateDto customerDto)
        {
            await _customerService.UpdateCustomerAsync(id, customerDto);
            return HandleResult(null, System.Net.HttpStatusCode.NoContent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return HandleResult(null, System.Net.HttpStatusCode.NoContent);
        }
    }
}
