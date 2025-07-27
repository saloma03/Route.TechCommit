using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.TechSummit.Abstraction.Services;
using Route.TechSummit.DTOs.InvoiceDTOs;

namespace Route.TechSummit.Application.Service.invoice
{
    internal class InvoiceService : IInvoiceService
    {
        public Task<InvoiceDto> CreateInvoiceAsync(InvoiceCreateDto invoiceDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteInvoiceAsync(int invoiceId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDto> GetInvoiceByIdAsync(int invoiceId)
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceDto> GetInvoiceByOrderIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
