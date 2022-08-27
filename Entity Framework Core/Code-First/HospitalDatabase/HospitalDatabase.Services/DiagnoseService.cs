using HospitalDatabase.Data;
using HospitalDatabase.Models;
using HospitalDatabase.Services.Contracts;
using System;
using System.Linq;
using System.Threading;

namespace HospitalDatabase.Services
{
    public class DiagnoseService : IDiagnoseService
    {
        private readonly HospitalDataContext context;

        public DiagnoseService(HospitalDataContext context)
        {
            this.context = context;
        }

        public void Add(string name, string firstName, string lastName, string comments = null)
        {
            Patient patient = context.Patients.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (patient == null)
            {
                Console.WriteLine("There is no such patient in the database!");
            }
            else
            {
                Diagnose diagnose = new Diagnose()
                {
                    Name = name,
                    Patient = patient,
                    Comments = comments
                };

                context.Diagnoses.Add(diagnose);
                context.SaveChanges();

                Console.WriteLine($"Diagnose: {diagnose.Name} successfully added for patient {patient.FirstName} {patient.LastName}!");
            }

            Thread.Sleep(2000);
        }

        public void Remove(string name, string firstName, string lastName)
        {
            throw new NotImplementedException();
        }
    }
}
