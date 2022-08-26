﻿using HospitalDatabase.Data;
using HospitalDatabase.Services.Models;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void RemoveMedication(string firstName, string lastName, string medicationName)
        {
            throw new NotImplementedException();
        }
    }
}
