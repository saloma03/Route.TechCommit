using Route.TechSummit.DTOs.OrderDTOs;

namespace Route.TechSummit.Abstraction.Services
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(OrderCreateDto orderDto);
        Task<OrderDto> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task UpdateOrderStatusAsync(int orderId, OrderUpdateDto orderDto);
        Task DeleteOrderAsync(int orderId);


    }
}
