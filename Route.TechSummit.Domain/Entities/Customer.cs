using Route.TechSummit.Domain.Common;

namespace Route.TechSummit.Domain.Entities
{
    public class Customer : BaseAuditableEntity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? LastPurchaseDate { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
