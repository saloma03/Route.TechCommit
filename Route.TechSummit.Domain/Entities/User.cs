using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.TechSummit.Domain.Common;
using Route.TechSummit.Domain.Enum;

namespace Route.TechSummit.Domain.Entities
{
    public class User : BaseAuditableEntity<int>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }
        public UserRole Role { get; set; }
        public int? CustomerId { get; set; }  // Link to Customer (if role=Customer)
        public Customer? Customer { get; set; }

    }
}
