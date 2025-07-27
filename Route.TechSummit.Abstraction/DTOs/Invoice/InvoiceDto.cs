namespace Route.TechSummit.Abstraction.DTOs.InvoiceDTOs
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class InvoiceCreateDto
    {
        public int OrderId { get; set; }
    }
}
