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

        public IEnumerable<DiagnoseDto> ListDiagnoses()
        {
            throw new NotImplementedException();
        }

        public void PrescribeMedication(string firstName, string lastName, string medicationName)
        {
            throw new NotImplementedException();
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

        public void RemoveMedication(string firstName, string lastName, string medicationName)
        {
            throw new NotImplementedException();
        }
    }
}
