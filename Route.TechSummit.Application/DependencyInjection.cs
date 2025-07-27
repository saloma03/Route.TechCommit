using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System.Reflection;
using Route.TechSummit.Abstraction.Services;
using Microsoft.Extensions.Configuration;
using Route.TechSummit.Application.Service.customer;
using Route.TechSummit.Application.Service.Customer;
using Route.TechSummit.Application.Service.order;
using Route.TechSummit.Application.Service.product;
using Route.TechSummit.Application.Service;
using Route.TechSummit.Application.Service.invoice;

namespace Route.TechSummit.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            // Register AutoMapper with assembly scanning
            services.AddAutoMapper(cfg =>
            {
                // Optionally configure mappings here if needed
            }, Assembly.GetExecutingAssembly());

            // Register application services
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInvoiceService, InvoiceService>();

            // Register ServiceManager
            services.AddScoped<IServiceManager, ServiceManager>();

            return services;
        }
    }
}