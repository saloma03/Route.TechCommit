﻿using Route.TechSummit.Domain.Common;

namespace Route.TechSummit.Domain.Entities
{
    public class OrderItem : BaseEntity<int>
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

    }
}
