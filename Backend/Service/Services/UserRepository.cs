using System.ComponentModel.Composition;
using System.IO;
using System.Threading.Tasks;
using Service.Interfaces;
using Service.Models;

namespace Service.Services
{
    [Export(typeof(IUserRepository))]
    public sealed class UserRepository : FileBasedRepository<string, User>, IUserRepository
    {
        [ImportingConstructor]
        public UserRepository(IItemsSerializer<string, User> serializer, IPathProvider pathProvider)
            : base(Path.Combine(pathProvider.BasePath, "users.json"), serializer)
        {
        }

        protected override async Task OnItemsLoaded(User[] items)
        {
            if (items.Length != 0)
                return;

            await AddOrUpdate(new User("admin", Util.GetPasswordHash("admin"), "admin"));
            await AddOrUpdate(new User("user", Util.GetPasswordHash("user")));
        }
    }
}