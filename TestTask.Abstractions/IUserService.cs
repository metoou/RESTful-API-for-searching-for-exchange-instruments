namespace TestTask.Abstractions
{
    public interface IUserService
    {
        bool ValidateCredentials(string username, string password);
    }
}
