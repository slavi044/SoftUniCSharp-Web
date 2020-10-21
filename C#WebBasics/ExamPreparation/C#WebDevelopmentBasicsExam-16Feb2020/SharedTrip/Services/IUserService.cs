namespace SharedTrip.Services
{
    public interface IUserService
    {
        string GetUserId(string username, string password);

        void Create(string username, string password, string email);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);
    }
}
