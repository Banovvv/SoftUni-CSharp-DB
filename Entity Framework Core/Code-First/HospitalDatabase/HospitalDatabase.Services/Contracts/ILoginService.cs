namespace HospitalDatabase.Services.Contracts
{
    public interface ILoginService
    {
        bool IsLoginSuccessfull(string email, string password);
    }
}
