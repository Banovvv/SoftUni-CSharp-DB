using HospitalDatabase.Data;
using HospitalDatabase.Models;
using HospitalDatabase.Services.Contracts;
using Microsoft.EntityFrameworkCore;
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
            Diagnose diagnose = context.Diagnoses.Include(x=>x.Patient).FirstOrDefault(x => x.Name == name && x.Patient.FirstName == firstName && x.Patient.LastName == lastName);

            if (diagnose == null)
            {
                Console.WriteLine("There is no such diagnose-patient combination in the database!");
            }
            else
            {
                context.Diagnoses.Remove(diagnose);
                context.SaveChanges();

                Console.WriteLine($"Diagnose: {diagnose.Name} successfully removed for patient {diagnose.Patient.FirstName} {diagnose.Patient.LastName}!");
            }

            Thread.Sleep(2000);
        }
    }
}
