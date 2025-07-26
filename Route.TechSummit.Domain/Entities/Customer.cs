using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.TechSummit.Domain.Common;

namespace Route.TechSummit.Domain.Entities
{
    public class Customer : BaseAuditableEntity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
