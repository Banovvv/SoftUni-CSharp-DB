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
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<BookCategory> BooksCategories { get; set; }

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

            modelBuilder.Entity<Book>(book =>
            {
                book.Property(x => x.Title)
                    .IsRequired(true)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                book.Property(x => x.Description)
                    .IsRequired(true)
                    .HasMaxLength(100)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Category>(category =>
            {
                category.Property(x => x.Name)
                    .IsRequired(true)
                    .HasMaxLength(50)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<BookCategory>(bookCategory =>
            {
                bookCategory
                    .HasKey(x => new { x.CategoryId, x.BookId });
            });
        }
    }
}
