// Application/DependencyInjection.cs
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Route.TechSummit.Application.Mapping;

namespace Route.TechSummit.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            // Register other application services
            return services;

        }
    }
}