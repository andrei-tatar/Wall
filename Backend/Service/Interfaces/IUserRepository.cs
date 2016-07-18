using Service.Models;

namespace Service.Interfaces
{
    public interface IUserRepository : IRepository<string, User> { }
}