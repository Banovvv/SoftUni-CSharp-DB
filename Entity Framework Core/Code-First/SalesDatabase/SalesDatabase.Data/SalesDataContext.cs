using Microsoft.EntityFrameworkCore;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
