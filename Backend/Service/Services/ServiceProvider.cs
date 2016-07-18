using Service.Interfaces;
using Service.Models;

namespace Service.Services
{
    //TODO: don't use a singleton
    public class ServiceProvider
    {
        public static readonly ServiceProvider Instance = new ServiceProvider();

        public IUserRepository UserRepository { get; }

        private ServiceProvider()
        {
            UserRepository = new UserRepository();

            UserRepository.Add(new User("admin", Util.GetPasswordHash("admin"), "admin", "user"));
            UserRepository.Add(new User("user", Util.GetPasswordHash("user"), "user"));
        }
    }
}