using HospitalDatabase.Data;
using HospitalDatabase.Services;
using HospitalDatabase.Services.Contracts;
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
                Console.WriteLine("8. Add medicament");
                Console.WriteLine("9. Remove medicament");
                Console.WriteLine("0. Exit");

                Console.Write("What would you like to do: ");
                bool isParsed = int.TryParse(Console.ReadLine(), out int choice);

                if (isParsed && choice == 0)
                {
                    break;
                }

                if (isParsed && (choice >= 1 && choice <= 9))
                {
                    switch (choice)
                    {
                        case 1:
                            AddPatient(context);
                            break;
                        case 2:
                            RemovePatient(context);
                            break;
                        case 3:
                            PrescribeMedication(context);
                            break;
                        case 4:
                            RemoveMedication(context);
                            break;
                        case 5:
                            AddDiagnose(context);
                            break;
                        case 6:
                            RemoveDiagnose(context);
                            break;
                        case 7:
                            AddVisitation(context);
                            break;
                        case 8:
                            AddMedicament(context);
                            break;
                        case 9:
                            RemoveMedicament(context);
                            break;
                    }
                }
            }
        }

        private static void AddPatient(HospitalDataContext context)
        {
            IPatientService service = new PatientService(context);

            Console.Write("Enter patient's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter patient's last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter patient's address: ");
            string address = Console.ReadLine();
            Console.Write("Enter patient's email: ");
            string email = Console.ReadLine();
            Console.Write("Does the patient has insurance (true/false): ");
            bool hasInsurance = bool.Parse(Console.ReadLine());

            service.Add(firstName, lastName, address, email, hasInsurance);
        }
        private static void RemovePatient(HospitalDataContext context)
        {
            IPatientService service = new PatientService(context);

            Console.Write("Enter patient's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter patient's last name: ");
            string lastName = Console.ReadLine();

            service.Remove(firstName, lastName);
        }
        private static void PrescribeMedication(HospitalDataContext context)
        {
            IPatientService service = new PatientService(context);

            Console.Write("Enter patient's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter patient's last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter medicament's name: ");
            string medicamentName = Console.ReadLine();

            service.PrescribeMedication(firstName, lastName, medicamentName);
        }
        private static void RemoveMedication(HospitalDataContext context)
        {
            IPatientService service = new PatientService(context);

            Console.Write("Enter patient's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter patient's last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter medicament's name: ");
            string medicamentName = Console.ReadLine();

            service.RemoveMedication(firstName, lastName, medicamentName);
        }
        private static void AddDiagnose(HospitalDataContext context)
        {
            IDiagnoseService service = new DiagnoseService(context);

            Console.Write("Enter diagnose name: ");
            string diagnose = Console.ReadLine();
            Console.Write("Enter patient's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter patient's last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter any comments: ");
            string comments = Console.ReadLine();

            service.Add(diagnose, firstName, lastName, comments);
        }
        private static void RemoveDiagnose(HospitalDataContext context)
        {
            IDiagnoseService service = new DiagnoseService(context);

            Console.Write("Enter diagnose name: ");
            string diagnose = Console.ReadLine();
            Console.Write("Enter patient's first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter patient's last name: ");
            string lastName = Console.ReadLine();

            service.Remove(diagnose, firstName, lastName);
        }
        private static void AddVisitation(HospitalDataContext context)
        {
            IVisitationService service = new VisitationService(context);

            Console.Write("Enter visitation date in the format day-month-year: ");
            string date = Console.ReadLine();
            Console.Write("Enter doctor ID: ");
            int doctorId = int.Parse(Console.ReadLine());
            Console.Write("Enter patient ID: ");
            int patientId = int.Parse(Console.ReadLine());

            service.Add(date, doctorId, patientId);
        }
        private static void AddMedicament(HospitalDataContext context)
        {
            IMedicamentService service = new MedicamentService(context);

            Console.Write("Enter medicament's name to add: ");
            string medicamentName = Console.ReadLine();

            service.Add(medicamentName);
        }
        private static void RemoveMedicament(HospitalDataContext context)
        {
            IMedicamentService service = new MedicamentService(context);

            Console.Write("Enter medicament's name to remove: ");
            string medicamentName = Console.ReadLine();

            service.Remove(medicamentName);
        }
    }
}
