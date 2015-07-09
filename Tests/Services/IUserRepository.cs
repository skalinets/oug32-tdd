namespace Tests.Services
{
    public interface IUserRepository
    {
        bool Exists(string userName);
        void Add(User user);
    }
}