using Route.TechSummit.Domain.Common;

namespace Route.TechSummit.Domain.Entities
{
    public class Product : BaseAuditableEntity<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

    }
}
