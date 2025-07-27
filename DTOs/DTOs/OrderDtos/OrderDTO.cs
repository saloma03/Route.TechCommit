using Route.TechSummit.Domain.Enum;

namespace Route.TechSummit.DTOs.OrderDTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public OrderStatus Status { get; set; }
    }

    public class OrderCreateDto
    {
        public int CustomerId { get; set; }
        public ICollection<OrderItemCreateDto> OrderItems { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }

    public class OrderUpdateDto
    {
        public OrderStatus Status { get; set; }
    }

    public class OrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
    }

    public class OrderItemCreateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
