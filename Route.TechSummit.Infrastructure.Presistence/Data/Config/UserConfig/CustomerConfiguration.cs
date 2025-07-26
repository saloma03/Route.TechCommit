
namespace Route.TechSummit.Infrastructure.Presistence.Data.Config.UserConfig
{
    internal class CustomerConfiguration : BaseAuditableConfigurations<Customer, int>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.IsActive)
                .HasDefaultValue(true);

            // Indexes
            builder.HasIndex(c => c.Email)
                .IsUnique();
        }
    }
}
