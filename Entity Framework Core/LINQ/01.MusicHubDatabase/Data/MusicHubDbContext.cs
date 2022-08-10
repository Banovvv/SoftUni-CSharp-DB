using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;

namespace MusicHub.Data
{
    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Writer> Writers { get; set; }
        public virtual DbSet<SongPerformer> SongsPerformers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Song>(song =>
            {
                song.Property(x => x.Name)
                    .HasMaxLength(20)
                    .IsRequired()
                    .IsUnicode(false);

                song.Property(x => x.Duration)
                    .IsRequired();

                song.Property(x => x.CreateOn)
                    .IsRequired();

                song.Property(x => x.Genre)
                    .IsRequired();
            });

            builder.Entity<Album>(album =>
            {
                album.Property(x => x.Name)
                    .HasMaxLength(40)
                    .IsRequired()
                    .IsUnicode(false);
            });

            builder.Entity<Performer>(performer =>
            {
                performer.Property(x => x.FirstName)
                    .HasMaxLength(20)
                    .IsRequired(true)
                    .IsUnicode(false);

                performer.Property(x => x.LastName)
                    .HasMaxLength(20)
                    .IsRequired(true)
                    .IsUnicode(false);
            });

            builder.Entity<Producer>(producer =>
            {
                producer.Property(x => x.Name)
                    .HasMaxLength(30)
                    .IsRequired(true)
                    .IsUnicode(false);
            });

            builder.Entity<Writer>(writer =>
            {
                writer.Property(x => x.Name)
                    .HasMaxLength(20)
                    .IsRequired(true)
                    .IsUnicode(false);
            });

            builder.Entity<SongPerformer>(songPerformer =>
            {
                songPerformer
                    .HasKey(x => new { x.SongId, x.PerformerId });
            });
        }
    }
}
