
using Route.TechSummit.Infrastructure.Presistence.Data.Config.Base;

namespace Route.TechSummit.Infrastructure.Presistence.Data.Config.OrderConfig
{
    internal class OrderItemConfiguration : BaseEntityConfigurations<OrderItem, int>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            base.Configure(builder);

            // Property configurations
            builder.Property(oi => oi.Quantity)
                .IsRequired();

            builder.Property(oi => oi.UnitPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(oi => oi.Discount)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            // Relationships
            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete when Order is deleted

            builder.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent delete if referenced by OrderItem

            builder.HasIndex(oi => oi.OrderId);
            builder.HasIndex(oi => oi.ProductId);

        }
    }
}
