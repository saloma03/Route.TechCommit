
namespace Route.TechSummit.Abstraction.Services
{
    public class IServiceManager
    {
        IProductService ProductService { get; }
        ICustomerService CustomerService { get; }
        IOrderService OrderService { get; }
        IUserService UserService { get; }
    }
}
