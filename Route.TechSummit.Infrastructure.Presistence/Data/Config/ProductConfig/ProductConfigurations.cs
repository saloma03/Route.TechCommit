
namespace Route.TechSummit.Infrastructure.Presistence.Data.Config.ProductConfig
{
    public class ProductConfigurations : BaseAuditableConfigurations<Product, int>

    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Stock)
                .IsRequired()
                .HasDefaultValue(0);

        }


    }
}
