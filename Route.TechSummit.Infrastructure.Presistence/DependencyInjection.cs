using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Route.TechSummit.Infrastructure.Presistence.Data;

namespace Route.TechSummit.Infrastructure.Presistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresistenceServices(this IServiceCollection services, IConfiguration configuration) => services.AddDbContext<TechSummitDbContext>(OptionsBuilder =>
                                                                                                                                        {
                                                                                                                                            OptionsBuilder.UseSqlServer(configuration.GetConnectionString("TechSummitContext"));
                                                                                                                                        });
    }
}
