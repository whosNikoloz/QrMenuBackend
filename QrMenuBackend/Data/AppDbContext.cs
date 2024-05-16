using Microsoft.EntityFrameworkCore;
using QrMenuBackend.Models;

namespace QrMenuBackend.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<OptionValue> OptionValues { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(22, 5); 

            modelBuilder.Entity<OptionValue>()
                .Property(ov => ov.Price)
                .HasPrecision(22, 5); 


            base.OnModelCreating(modelBuilder);

        }
    }
}
