﻿using Microsoft.EntityFrameworkCore;
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
                    .HasKey(c => c.Id);

                course
                    .Property(c => c.Description)
                    .IsRequired(false)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Student>(student =>
            {
                student
                    .HasKey(s => s.Id);

                student
                    .Property(s=>s.Name)
                    .IsUnicode(true);

                student
                    .Property(s => s.PhoneNumber)
                    .IsRequired(false)
                    .IsUnicode(false);
            });
        }

    }
}
