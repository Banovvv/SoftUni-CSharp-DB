using HospitalDatabase.Data;
using HospitalDatabase.Models;
using HospitalDatabase.Services.Contracts;
using System;
using System.Linq;
using System.Threading;

namespace HospitalDatabase.Services
{
    public class MedicamentService : IMedicamentService
    {
        private readonly HospitalDataContext context;

        public MedicamentService(HospitalDataContext context)
        {
            this.context = context;
        }

        public void Add(string medicamentName)
        {
            if (context.Medicaments.FirstOrDefault(x => x.Name == medicamentName) != null)
            {
                Console.WriteLine("The specified medicament is already in the list!");
            }

            Medicament medicament = new Medicament()
            {
                Name = medicamentName
            };

            context.Medicaments.Add(medicament);
            context.SaveChanges();

            Console.WriteLine("Medicament successfully added to the list of medicaments!");

            Thread.Sleep(2000);
        }

        public void Remove(string medicamentName)
        {
            Medicament medicament = context.Medicaments.FirstOrDefault(x => x.Name == medicamentName);

            if (medicament == null)
            {
                Console.WriteLine("There is no such medicament in the database!");
            }
            else
            {
                context.Medicaments.Remove(medicament);
                context.SaveChanges();

                Console.WriteLine("Medicament successfully removed!");
            }

            Thread.Sleep(2000);
        }
    }
}
