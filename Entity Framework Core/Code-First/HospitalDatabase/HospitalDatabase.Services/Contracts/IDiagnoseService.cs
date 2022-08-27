namespace HospitalDatabase.Services.Contracts
{
    public interface IDiagnoseService
    {
        void Add(string name, string firstName, string lastName, string comments = null);
        void Remove(string name, string firstName, string lastName);
    }
}
