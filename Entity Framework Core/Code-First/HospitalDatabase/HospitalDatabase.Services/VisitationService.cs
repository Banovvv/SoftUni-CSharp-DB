using HospitalDatabase.Services.Contracts;
using System;

namespace HospitalDatabase.Services
{
    public class VisitationService : IVisitationService
    {
        public void Add(string date, int doctorId, int patientId, string comments = null)
        {
            throw new NotImplementedException();
        }
    }
}
