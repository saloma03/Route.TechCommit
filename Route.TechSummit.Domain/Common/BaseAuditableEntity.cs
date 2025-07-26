using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.TechSummit.Domain.Common
{
    public abstract class BaseAuditableEntity<Tkey> : BaseEntity<Tkey>
        where Tkey : IEquatable<Tkey>
    {
        public String CreatedBy { get; set; }
        public required DateTime CreatedOn { get; set; } /*= DateTime.UtcNow; */

        public required String LastUpdatedBy { get; set; }

        public DateTime LastUpdatedOn { get; set; }/* = DateTime.UtcNow; */

    }
}
