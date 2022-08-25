using System.Collections.Generic;

namespace HospitalDatabase.Models
{
    public class Medicament
    {
        public Medicament()
        {
            Prescriptions = new HashSet<PatientMedicament>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
