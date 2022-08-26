﻿namespace HospitalDatabase.Services.Contracts
{
    public interface IDiagnoseService
    {
        void Add(string name, int patientId, string comments = null);
        void Remove(string name, int patientId);
    }
}
