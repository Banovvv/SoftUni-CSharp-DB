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
                        case 1: break;
                        case 2: break;
                        case 3: break;
                        case 4: break;
                        case 5: break;
                        case 6: break;
                        case 7: break;
                    }
                }
            }
        }
    }
}
