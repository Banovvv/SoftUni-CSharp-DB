using HospitalDatabase.Data;
using HospitalDatabase.Models;
using HospitalDatabase.Services.Contracts;
using HospitalDatabase.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HospitalDatabase.Services
{
    public class PatientService : IPatientService
    {
        private readonly HospitalDataContext context;

        public PatientService(HospitalDataContext context)
        {
            this.context = context;
        }

        public void Add(string firstName, string lastName, string address, string email, bool hasInsurance)
        {
            Patient patient = new Patient()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Email = email,
                HasInsurance = hasInsurance
            };

            context.Patients.Add(patient);

            context.SaveChanges();
        }

        public void Remove(string firstName, string lastName)
        {
            Patient patient = context.Patients.Where(x => x.FirstName == firstName && x.LastName == lastName).FirstOrDefault();

            if (patient == null)
            {
                Console.WriteLine("There is no such patient in the database!");
            }
            else
            {
                context.Patients.Remove(patient);
                context.SaveChanges();

                Console.WriteLine("Patient successfully removed!");
            }

            Thread.Sleep(2000);
        }

        public IEnumerable<DiagnoseDto> ListDiagnoses()
        {
            throw new NotImplementedException();
        }

        public void PrescribeMedication(string firstName, string lastName, string medicamentName)
        {
            Patient patient = context.Patients.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (patient == null)
            {
                Console.WriteLine("There is no such patient in the database!");
                return;
            }

            Medicament medicament = context.Medicaments.FirstOrDefault(x => x.Name == medicamentName);
            if (medicament == null)
            {
                Console.WriteLine("There is no such medicament in the database!");
                return;
            }

            var patientMedicament = new PatientMedicament()
            {
                Patient = patient,
                Medicament = medicament
            };

            context.PatientMedicaments.Add(patientMedicament);
            context.SaveChanges();

            Console.WriteLine($"{medicament.Name} successfully perscribed to {patient.FirstName} {patient.LastName}!");

            Thread.Sleep(2000);
        }

        public void RemoveMedication(string firstName, string lastName, string medicamentName)
        {
            Patient patient = context.Patients.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (patient == null)
            {
                Console.WriteLine("There is no such patient in the database!");
                return;
            }

            Medicament medicament = context.Medicaments.FirstOrDefault(x => x.Name == medicamentName);
            if (medicament == null)
            {
                Console.WriteLine("There is no such medicament in the database!");
                return;
            }

            var patientMedicament = new PatientMedicament()
            {
                Patient = patient,
                Medicament = medicament
            };

            context.PatientMedicaments.Remove(patientMedicament);
            context.SaveChanges();

            Console.WriteLine($"{medicament.Name} successfully removed from {patient.FirstName} {patient.LastName}'s list of medications!");

            Thread.Sleep(2000);
        }
    }
}
