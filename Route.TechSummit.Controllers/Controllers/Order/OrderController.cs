using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Route.TechSummit.Abstraction.Services;
using Route.TechSummit.Application.DTOs.OrderDTOs;
using Route.TechSummit.Controllers.Controllers.Base;

namespace Route.TechSummit.Controllers
{
    public class OrderController : BaseApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto orderDto)
        {
            var order = await _orderService.CreateOrderAsync(orderDto);
            return HandleResult(order, System.Net.HttpStatusCode.Created);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById( int orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            return HandleResult(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return HandleResult(orders);
        }

        [HttpPut("{orderId}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] OrderUpdateDto orderDto)
        {
            await _orderService.UpdateOrderStatusAsync(orderId, orderDto);
            return HandleResult(null, System.Net.HttpStatusCode.NoContent);
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            await _orderService.DeleteOrderAsync(orderId);
            return HandleResult(null, System.Net.HttpStatusCode.NoContent);
        }
    }
}
