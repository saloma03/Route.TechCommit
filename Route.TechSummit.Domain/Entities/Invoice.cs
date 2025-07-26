using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.TechSummit.Domain.Common;
namespace Route.TechSummit.Domain.Entities
{
    public class Invoice : BaseAuditableEntity<int>
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
