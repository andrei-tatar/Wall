using System.ComponentModel.Composition;
using Service.Interfaces;
using Service.Models;

namespace Service.Services
{
    [Export(typeof(IUserRepository))]
    public class UserRepository : BaseMemoryRepository<string, User>, IUserRepository
    {
        [ImportingConstructor]
        public UserRepository()
        {
            Add(new User("admin", Util.GetPasswordHash("admin"), "admin", "user"));
            Add(new User("user", Util.GetPasswordHash("user"), "user"));
        }
    }
}