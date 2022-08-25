using HospitalDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalDatabase.Data
{
    public class HospitalDataContext : DbContext
    {
        public HospitalDataContext()
        {
        }

        public HospitalDataContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<Diagnose> Diagnoses { get; set; }
        public virtual DbSet<Visitation> Visitations { get; set; }
        public virtual DbSet<PatientMedicament> PatientMedicaments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(patient =>
            {
                patient.Property(x => x.FirstName)
                    .IsRequired(true)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                patient.Property(x => x.LastName)
                    .IsRequired(true)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                patient.Property(x => x.Address)
                    .IsRequired(true)
                    .HasMaxLength(250)
                    .IsUnicode(true);

                patient.Property(x => x.FirstName)
                    .IsRequired(true)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Visitation>(visitation =>
            {
                visitation.Property(x => x.Comments)
                    .IsRequired(false)
                    .HasMaxLength(250)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Diagnose>(diagnose =>
            {
                diagnose.Property(x => x.Name)
                    .IsRequired(true)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                diagnose.Property(x => x.Comments)
                    .IsRequired(false)
                    .HasMaxLength(250)
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Medicament>(medicament =>
            {
                medicament.Property(x => x.Name)
                    .IsRequired(true)
                    .HasMaxLength(50)
                    .IsUnicode(true);
            });
        }
    }
}
