using System.Collections.Generic;

namespace HospitalDatabase.Models
{
    public class Doctor
    {
        public Doctor()
        {
            Visitations = new HashSet<Visitation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
