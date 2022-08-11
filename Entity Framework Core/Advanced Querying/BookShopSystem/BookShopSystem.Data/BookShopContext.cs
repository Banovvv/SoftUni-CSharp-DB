using BookShopSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShopSystem.Data
{
    public class BookShopContext : DbContext
    {
        public BookShopContext()
        {

        }

        public BookShopContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(author =>
            {
                author.Property(x => x.FirstName)
                    .IsRequired(false)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                author.Property(x => x.LastName)
                    .IsRequired(true)
                    .HasMaxLength(50)
                    .IsUnicode(true);
            });
        }
    }
}
