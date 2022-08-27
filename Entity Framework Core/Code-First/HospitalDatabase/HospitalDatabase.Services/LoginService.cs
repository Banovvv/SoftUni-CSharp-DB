using HospitalDatabase.Data;
using HospitalDatabase.Models;
using HospitalDatabase.Services.Contracts;
using System.Linq;

namespace HospitalDatabase.Services
{
    public class LoginService : ILoginService
    {
        private readonly HospitalDataContext context;

        public LoginService(HospitalDataContext context)
        {
            this.context = context;
        }

        public bool IsLoginSuccessfull(string email, string password)
        {
            Doctor doctor = context.Doctors.FirstOrDefault(x => x.Email == email && x.Password == password);

            return doctor != null;
        }
    }
}
