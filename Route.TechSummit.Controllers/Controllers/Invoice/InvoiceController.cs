using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Route.TechSummit.Abstraction.Services;
using Route.TechSummit.Controllers.Controllers.Base;
using Route.TechSummit.DTOs.InvoiceDTOs;

namespace Route.TechSummit.Controllers
{
    public class InvoiceController : BaseApiController
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] InvoiceCreateDto invoiceDto)
        {
            var invoice = await _invoiceService.CreateInvoiceAsync(invoiceDto);
            return HandleResult(invoice, System.Net.HttpStatusCode.Created);
        }

        [HttpGet("{invoiceId}")]
        public async Task<IActionResult> GetInvoiceById(int invoiceId)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(invoiceId);
            return HandleResult(invoice);
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetInvoiceByOrderId(int orderId)
        {
            var invoice = await _invoiceService.GetInvoiceByOrderIdAsync(orderId);
            return HandleResult(invoice);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync();
            return HandleResult(invoices);
        }

        [HttpDelete("{invoiceId}")]
        public async Task<IActionResult> DeleteInvoice( int invoiceId)
        {
            await _invoiceService.DeleteInvoiceAsync(invoiceId);
            return HandleResult(null, System.Net.HttpStatusCode.NoContent);
        }
    }
}
