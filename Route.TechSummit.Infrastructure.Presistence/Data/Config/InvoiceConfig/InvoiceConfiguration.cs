
namespace Route.TechSummit.Infrastructure.Presistence.Data.Config.InvoiceConfig
{
    internal class InvoiceConfiguration : BaseAuditableConfigurations<Invoice , int>
    {
        public override void Configure(EntityTypeBuilder<Invoice> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.TotalAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            // Relationship configuration
            builder.HasOne(i => i.Order)
                .WithOne() // Assuming one-to-one relationship
                .HasForeignKey<Invoice>(i => i.OrderId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent order deletion if invoice exists

            // Index for better query performance
            builder.HasIndex(i => i.OrderId)
                .IsUnique(); // Enforce one invoice per order


        }
    }
}
