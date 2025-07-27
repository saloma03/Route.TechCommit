using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.TechSummit.Domain.Entities;

namespace Route.TechSummit.Domain.Contracts
{
    public interface IInvoiceRepository : IGenericRepository<Invoice, int>
    {
        Task<Invoice> GetInvoiceByOrderIdAsync(int orderId);
    }
}
