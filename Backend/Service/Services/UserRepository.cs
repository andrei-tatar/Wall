using Service.Interfaces;
using Service.Models;

namespace Service.Services
{
    public class UserRepository : BaseMemoryRepository<string, User>, IUserRepository { }
}