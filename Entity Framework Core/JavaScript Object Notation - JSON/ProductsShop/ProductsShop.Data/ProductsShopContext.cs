using Microsoft.EntityFrameworkCore;
using ProductsShop.Models;

namespace ProductsShop.Data
{
    public class ProductsShopContext : DbContext
    {
        public ProductsShopContext()
        {
        }

        public ProductsShopContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.Property(x=>x.FirstName)
                    .IsRequired(false)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                user.Property(x => x.LastName)
                    .IsRequired(true)
                    .HasMaxLength(50)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Product>(product =>
            {
                product.Property(x => x.Name)
                    .IsRequired(true)
                    .HasMaxLength(100)
                    .IsUnicode(true);
            });
        }
    }
}
