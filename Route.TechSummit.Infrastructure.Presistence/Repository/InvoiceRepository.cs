using Route.TechSummit.Domain.Contracts;
using Route.TechSummit.Infrastructure.Presistence.Data;
namespace Route.TechSummit.Infrastructure.Presistence.Repository
{
    public class InvoiceRepository : GenericRepository<Invoice, int>, IInvoiceRepository
    {
        private readonly TechSummitDbContext _dbContext;

        public InvoiceRepository(TechSummitDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Invoice> GetInvoiceByOrderIdAsync(int  orderId)
        {
            return await _dbContext.Invoices
                .FirstOrDefaultAsync(i => i.OrderId == orderId);
        }
    }
}
