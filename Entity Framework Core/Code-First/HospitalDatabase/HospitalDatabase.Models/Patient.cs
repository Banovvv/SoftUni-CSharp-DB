using System.Collections.Generic;

namespace HospitalDatabase.Models
{
    public class Patient
    {
        public Patient()
        {
            Diagnoses = new HashSet<Diagnose>();
            Visitations = new HashSet<Visitation>();
            Prescriptions = new HashSet<PatientMedicament>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool HasInsurance { get; set; }

        public virtual ICollection<Diagnose> Diagnoses { get; set; }
        public virtual ICollection<Visitation> Visitations { get; set; }
        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
