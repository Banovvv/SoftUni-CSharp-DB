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
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryProduct> CategoryProducts { get; set; }

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
                user.Property(x => x.FirstName)
                    .IsRequired(false)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                user.Property(x => x.LastName)
                    .IsRequired(true)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                user.HasMany(x => x.ProductsBought)
                      .WithOne(x => x.Buyer)
                      .HasForeignKey(x => x.BuyerId);

                user.HasMany(x => x.ProductsSold)
                      .WithOne(x => x.Seller)
                      .HasForeignKey(x => x.SellerId);
            });

            modelBuilder.Entity<Product>(product =>
            {
                product.Property(x => x.Name)
                    .IsRequired(true)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Category>(category =>
            {
                category.Property(x => x.Name)
                    .IsRequired(true)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<CategoryProduct>(categoryProduct =>
            {
                categoryProduct
                    .HasKey(x => new { x.CategoryId, x.ProductId });
            });
        }
    }
}
