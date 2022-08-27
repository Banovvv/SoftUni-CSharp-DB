using Microsoft.EntityFrameworkCore;
using SalesDatabase.Models;

namespace SalesDatabase.Data
{
    public class SalesDataContext : DbContext
    {
        public SalesDataContext()
        {
        }

        public SalesDataContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>(store =>
            {
                store.Property(x => x.Name)
                    .IsRequired(true)
                    .HasMaxLength(80)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Product>(product =>
            {
                product.Property(x => x.Name)
                       .IsRequired(true)
                       .HasMaxLength(50)
                       .IsUnicode(true);

            });

            modelBuilder.Entity<Customer>(customer =>
            {
                customer.Property(x => x.Name)
                       .IsRequired(true)
                       .HasMaxLength(100)
                       .IsUnicode(true);

                customer.Property(x => x.Email)
                       .IsRequired(true)
                       .HasMaxLength(80)
                       .IsUnicode(true);

            });
        }
    }
}
