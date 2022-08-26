using HospitalDatabase.Services.Models;
using System.Collections.Generic;

namespace HospitalDatabase.Services
{
    public interface IPatientService
    {
        void Add(string firstName, string lastName, string address, string email, bool hasInsurance);
        void Remove(string firstName, string lastName);
        void PrescribeMedication(string firstName, string lastName, string medicationName);
        void RemoveMedication(string firstName, string lastName, string medicationName);
        IEnumerable<DiagnoseDto> ListDiagnoses();
    }
}
