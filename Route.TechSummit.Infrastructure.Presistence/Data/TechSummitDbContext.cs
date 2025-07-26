using Route.TechSummit.Domain.Entities;

namespace Route.TechSummit.Infrastructure.Presistence.Data
{
    public class TechSummitDbContext : DbContext
    {
        public TechSummitDbContext(DbContextOptions<TechSummitDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships, indexes, etc.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechSummitDbContext).Assembly);
        }

    }
}
