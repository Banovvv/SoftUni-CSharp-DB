namespace HospitalDatabase.Services.Contracts
{
    public interface IVisitationService
    {
        void Add(string date, int doctorId, int patientId, string comments = null);
    }
}
