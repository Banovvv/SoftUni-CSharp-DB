using Microsoft.EntityFrameworkCore;
using ProductShop.Models;

namespace ProductShop.Data
{
    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {
        }

        public ProductShopContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryProduct> CategoryProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(product =>
            {
                product.HasOne(e => e.Buyer)
                .WithMany(u => u.ProductsBought)
                .HasForeignKey(e => e.BuyerId);

                product.HasOne(e => e.Seller)
                    .WithMany(u => u.ProductsSold)
                    .HasForeignKey(e => e.SellerId);
            });

            modelBuilder.Entity<CategoryProduct>(categoryProduct =>
            {
                categoryProduct.HasKey(x => new { x.CategoryId, x.ProductId });
            });
        }
    }
}
