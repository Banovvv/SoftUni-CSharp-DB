using HospitalDatabase.Data;
using HospitalDatabase.Models;
using HospitalDatabase.Services.Contracts;
using System;
using System.Linq;
using System.Threading;

namespace HospitalDatabase.Services
{
    public class VisitationService : IVisitationService
    {
        private readonly HospitalDataContext context;

        public VisitationService(HospitalDataContext context)
        {
            this.context = context;
        }

        public void Add(string date, int doctorId, int patientId, string comments = null)
        {
            if (DateTime.TryParse(date, out DateTime dt))
            {
                Doctor doctor = context.Doctors.FirstOrDefault(x => x.Id == doctorId);
                Patient patient = context.Patients.FirstOrDefault(x => x.Id == patientId);

                if (doctor == null)
                {
                    Console.WriteLine($"No doctor with ID {doctorId} in the database!");
                }
                else if (patient == null)
                {
                    Console.WriteLine($"No patient with ID {patientId} in the database!");
                }
                else
                {
                    Visitation visitation = new Visitation()
                    {
                        Date = dt,
                        Doctor = doctor,
                        Patient = patient
                    };

                    context.Visitations.Add(visitation);
                    context.SaveChanges();

                    Console.WriteLine($"Visitation on {dt.ToShortDateString()} for patient {patient.FirstName} {patient.LastName} by doctor {doctor.Name} added to the database!");
                }
            }
            else
            {
                Console.WriteLine("Invalid date!");
            }

            Thread.Sleep(2000);
        }
    }
}
