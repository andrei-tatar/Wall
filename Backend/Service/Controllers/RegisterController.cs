using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Web.Http;
using Service.Interfaces;
using Service.Models;

namespace Service.Controllers
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class RegisterController : ApiController
    {
        private readonly IUserRepository _userRepository;

        [ImportingConstructor]
        public RegisterController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IHttpActionResult> Post([FromBody] UserRegisterData user)
        {
            if (user == null)
                return BadRequest("Invalid registration data");

            var userModel = await _userRepository.Get(user.Id);
            if (userModel != null)
                return Ok("User already registered");

            await _userRepository.Add(new User(user.Id, Util.GetPasswordHash(user.Password), user.Role));
            return Ok("User registered successfully");
        }

        public class UserRegisterData
        {
            public string Id { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
        }
    }
}