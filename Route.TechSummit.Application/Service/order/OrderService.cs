using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Route.TechSummit.Abstraction.DTOs.InvoiceDTOs;
using Route.TechSummit.Abstraction.Services;
using Route.TechSummit.Application.DTOs.OrderDTOs;
using Route.TechSummit.Domain.Entities;
using Route.TechSummit.Domain.Enum;
using Route.TechSummit.Infrastructure.Repository;

namespace Route.TechSummit.Application.Service.order
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateOrderAsync(OrderCreateDto orderDto)
        {
            // 1. Validate products and update stock
            foreach (var item in orderDto.OrderItems)
            {
                var product = await _repositoryManager.ProductRepository.GetByIdAsync(item.ProductId);
                if (product == null || product.Stock < item.Quantity)
                {
                    throw new Exception($"Product {product?.Name ?? item.ProductId.ToString()} is out of stock or does not exist.");
                }
                // Update stock (will be saved with the order transaction)
                product.Stock -= item.Quantity;
                await _repositoryManager.ProductRepository.UpdateAsync(product);
            }

            // 2. Calculate total amount and apply discounts (simplified for now)
            var order = _mapper.Map<Order>(orderDto);
            order.CreatedOn = DateTime.UtcNow;
            order.Status = OrderStatus.Pending;
            order.TotalAmount = 0;

            foreach (var item in order.OrderItems)
            {
                var product = await _repositoryManager.ProductRepository.GetByIdAsync(item.ProductId);
                if (product != null)
                {
                    item.UnitPrice = product.Price;
                    // Apply discount logic here if needed
                    item.Discount = 0; // Placeholder
                    order.TotalAmount += (item.Quantity * item.UnitPrice) * (1 - item.Discount);
                }
            }

            // 3. Create order
            await _repositoryManager.OrderRepository.AddAsync(order);
            await _repositoryManager.UnitOfWork.CompleteAsync();

            // 4. Generate invoice (simplified for now)
            var invoice = new InvoiceCreateDto { OrderId = order.Id };
            await _repositoryManager.InvoiceRepository.AddAsync(_mapper.Map<Invoice>(invoice));
            await _repositoryManager.UnitOfWork.CompleteAsync();

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> GetOrderByIdAsync(int orderId)
        {
            var order = await _repositoryManager.OrderRepository.GetOrderWithItemsAsync(orderId);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _repositoryManager.OrderRepository.GetAllOrdersWithItemsAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task UpdateOrderStatusAsync(int orderId, OrderUpdateDto orderDto)
        {
            var order = await _repositoryManager.OrderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                // Handle not found exception
                return;
            }
            _mapper.Map(orderDto, order);
            await _repositoryManager.OrderRepository.UpdateAsync(order);
            await _repositoryManager.UnitOfWork.CompleteAsync();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await _repositoryManager.OrderRepository.DeleteAsync(orderId);
            await _repositoryManager.UnitOfWork.CompleteAsync();
        }
    }
}
