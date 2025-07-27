using Route.TechSummit.Domain.Contracts;
using Route.TechSummit.Infrastructure.Presistence.UnitOfWork;

namespace Route.TechSummit.Infrastructure.Repository
{
    public interface IRepositoryManager
    {
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IUserRepository UserRepository { get; }
        IUnitOfWork UnitOfWork { get; }

    }
}