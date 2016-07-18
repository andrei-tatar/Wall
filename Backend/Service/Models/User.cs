using Service.Interfaces;

namespace Service.Models
{
    public class User : IIdentifiable<string>
    {
        public User(string id, string passwordHash)
        {
            Id = id;
            PasswordHash = passwordHash;
        }

        public string Id { get; }
        public string PasswordHash { get; }
    }
}