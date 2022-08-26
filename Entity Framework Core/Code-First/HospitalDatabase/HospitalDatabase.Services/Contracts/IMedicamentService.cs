namespace HospitalDatabase.Services.Contracts
{
    public interface IMedicamentService
    {
        void Add(string medicamentName);
        void Remove(string medicamentName);
    }
}
