using HospitalDatabase.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace HospitalDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new HospitalDataContext();
            context.Database.Migrate();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add a patient");
                Console.WriteLine("2. Remove a patient");
                Console.WriteLine("3. Prescribe medication to a patient");
                Console.WriteLine("4. Remove patient medication");
                Console.WriteLine("5. Add diagnose");
                Console.WriteLine("6. Remove diagnose");
                Console.WriteLine("7. Add visitation");

                Console.Write("What would you like to do: ");
                bool isParsed = int.TryParse(Console.ReadLine(), out int choice);

                if (isParsed && (choice >= 1 && choice <= 7))
                {
                    switch (choice)
                    {
                        case 1:
                            AddPatient();
                            break;
                        case 2:
                            RemovePatient();
                            break;
                        case 3:
                            PrescribeMedication();
                            break;
                        case 4:
                            RemoveMedication(); 
                            break;
                        case 5:
                            AddDiagnose();
                            break;
                        case 6:
                            RemoveDiagnose();
                            break;
                        case 7:
                            AddVisitation();
                            break;
                    }
                }
            }
        }

        private static void AddPatient()
        {
            throw new NotImplementedException();
        }
        private static void RemovePatient()
        {
            throw new NotImplementedException();
        }
        private static void PrescribeMedication()
        {
            throw new NotImplementedException();
        }
        private static void RemoveMedication()
        {
            throw new NotImplementedException();
        }
        private static void AddDiagnose()
        {
            throw new NotImplementedException();
        }
        private static void RemoveDiagnose()
        {
            throw new NotImplementedException();
        }
        private static void AddVisitation()
        {
            throw new NotImplementedException();
        }
    }
}
