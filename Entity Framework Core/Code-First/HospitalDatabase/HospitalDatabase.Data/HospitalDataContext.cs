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

        }
    }
}
