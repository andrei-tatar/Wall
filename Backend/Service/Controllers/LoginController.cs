using System.Threading.Tasks;
using System.Web.Http;
using Service.Services;

namespace Service.Controllers
{
    public class LoginController : ApiController
    {
        public async Task<IHttpActionResult> Post([FromBody]UserEntity user)
        {
            var userModel = await ServiceProvider.Instance.UserRepository.Get(user.User);
            if (userModel == null || userModel.PasswordHash != Util.GetPasswordHash(user.Password))
                return Unauthorized();

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