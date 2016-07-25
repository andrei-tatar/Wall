using System.ComponentModel.Composition;
using Service.Interfaces;
using Service.Models;

namespace Service.Services
{
    [Export(typeof(IUserRepository))]
    public sealed class UserRepository : JsonRepository<string, User>, IUserRepository
    {
        [ImportingConstructor]
        public UserRepository(IFileRepositorySerializer<string,User> serializer) : base(serializer)
        {
            LoadUsers();

            Add(new User("admin", Util.GetPasswordHash("admin"), "admin", "user"));
            Add(new User("user", Util.GetPasswordHash("user"), "user"));
        }
    }
}