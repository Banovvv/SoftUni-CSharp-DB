using HospitalDatabase.Data;
using System;

namespace HospitalDatabase.Services
{
    public class DiagnoseService : IDiagnoseService
    {
        private readonly HospitalDataContext context;

        public DiagnoseService(HospitalDataContext context)
        {
            this.context = context;
        }

        public void Add(string name, int patientId, string comments = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(string name, int patientId)
        {
            throw new NotImplementedException();
        }
    }
}
