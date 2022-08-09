using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=FootbalBetting;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>(color =>
            {
                color.Property(x => x.Name)
                    .IsRequired()
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Country>(country =>
            {
                country.Property(x => x.Name)
                    .IsRequired()
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Player>(player =>
            {
                player.Property(x => x.Name)
                    .IsRequired()
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Position>(position =>
            {
                position.Property(x => x.Name)
                    .IsRequired()
                    .IsUnicode(true);
            });
        }
    }
}
