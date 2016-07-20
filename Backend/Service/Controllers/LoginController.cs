using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Web.Http;
using Service.Interfaces;

namespace Service.Controllers
{
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class LoginController : ApiController
    {
        private readonly IUserRepository _userRepository;

        [ImportingConstructor]
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IHttpActionResult> Post([FromBody]UserEntity user)
        {
            if (user == null)
                return BadRequest("Invalid user or password");

            var userModel = await _userRepository.Get(user.User);
            if (userModel == null || userModel.PasswordHash != Util.GetPasswordHash(user.Password))
                return BadRequest("Invalid user or password");

            var token = Util.UserToToken(user.User);
            return Ok($"Bearer {token}");
        }

        public class UserEntity
        {
            public string User { get; set; }
            public string Password { get; set; }
        }
    }
}