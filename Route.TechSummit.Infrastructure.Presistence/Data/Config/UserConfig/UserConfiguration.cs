

namespace Route.TechSummit.Infrastructure.Presistence.Data.Config.UserConfig
{
    internal class UserConfiguration : BaseAuditableConfigurations<User, int>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.PasswordHash)
                .IsRequired();

            builder.Property(u => u.Role)
                .IsRequired()
                .HasConversion<string>();

        }
    }
}
