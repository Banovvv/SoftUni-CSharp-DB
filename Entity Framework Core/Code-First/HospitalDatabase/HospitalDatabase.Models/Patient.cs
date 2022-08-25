namespace HospitalDatabase.Models
{
    public class Patient
    {
        public Patient()
        {

        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool HasInsurance { get; set; }
    }
}
