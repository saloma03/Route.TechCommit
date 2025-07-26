using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route.TechSummit.Domain.Entities;
using Route.TechSummit.Infrastructure.Persistence.Data.Config.Base;

namespace Route.TechSummit.Infrastructure.Presistence.Data.Config.ProductConfig
{
    public class ProductConfigurations : BaseAuditableConfigurations<Product, int>

    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

        }


    }
}
