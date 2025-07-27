

using Route.TechSummit.DTOs.InvoiceDTOs;

namespace Route.TechSummit.Abstraction.Services
{
    public interface IInvoiceService
    {
        Task<InvoiceDto> CreateInvoiceAsync(InvoiceCreateDto invoiceDto);
        Task<InvoiceDto> GetInvoiceByIdAsync(int invoiceId);
        Task<InvoiceDto> GetInvoiceByOrderIdAsync(int orderId);
        Task<IEnumerable<InvoiceDto>> GetAllInvoicesAsync();
        Task DeleteInvoiceAsync(int invoiceId);
    }
}




