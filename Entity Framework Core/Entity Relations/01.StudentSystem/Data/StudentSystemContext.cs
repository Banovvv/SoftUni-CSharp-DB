using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=StudentSystem;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(course =>
            {
                course
                    .HasKey(x => x.Id);

                course 
                    .Property(x => x.Description)
                    .IsRequired(false)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Student>(student =>
            {
                student
                    .HasKey(x => x.Id);

                student
                    .Property(x=>x.Name)
                    .IsUnicode(true);

                student
                    .Property(x => x.PhoneNumber)
                    .IsFixedLength(true)
                    .IsRequired(false)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Resource>(resource =>
            {
                resource
                    .Property(x => x.Name)
                    .IsUnicode(false);

                resource
                    .Property(x => x.Url)
                    .IsUnicode(false);
            });
        }

    }
}
