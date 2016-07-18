using Service.Interfaces;

namespace Service.Models
{
    public class User : IIdentifiable<string>
    {
        public User(string id, string passwordHash, params string[] roles)
        {
            Id = id;
            PasswordHash = passwordHash;
            Roles = roles;
        }

        public string Id { get; }
        public string PasswordHash { get; }
        public string[] Roles { get; }
    }
}