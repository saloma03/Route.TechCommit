using Route.TechSummit.Domain.Contracts;
using Route.TechSummit.Domain.Entities;
using Route.TechSummit.Infrastructure.Presistence.Data;
using Route.TechSummit.Infrastructure.Presistence.UnitOfWork;
using Route.TechSummit.Infrastructure.Presistence.Repository;
using Route.TechSummit.Infrastructure.Presistence.Repository;

namespace Route.TechSummit.Infrastructure.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly TechSummitDbContext _dbContext;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IOrderRepository> _orderRepository;
        private readonly Lazy<IInvoiceRepository> _invoiceRepository;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IUnitOfWork> _unitOfWork;

        public RepositoryManager(TechSummitDbContext dbContext)
        {
            _dbContext = dbContext;
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_dbContext));
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(_dbContext));
            _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(_dbContext));
            _invoiceRepository = new Lazy<IInvoiceRepository>(() => new InvoiceRepository(_dbContext));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_dbContext));
            _unitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(_dbContext));
        }

        public IProductRepository ProductRepository => _productRepository.Value;
        public ICustomerRepository CustomerRepository => _customerRepository.Value;
        public IOrderRepository OrderRepository => _orderRepository.Value;
        public IInvoiceRepository InvoiceRepository => _invoiceRepository.Value;
        public IUserRepository UserRepository => _userRepository.Value;
        public IUnitOfWork UnitOfWork => _unitOfWork.Value;
    }
}
