using System.Threading.Tasks;
using System.Web.Http;
using Service.Services;

namespace Service.Controllers
{
    public class LoginController : ApiController
    {
        public async Task<IHttpActionResult> Post(string user, string password)
        {
            var userModel = await ServiceProvider.Instance.UserRepository.Get(user);
            if (userModel == null || userModel.PasswordHash != Util.GetPasswordHash(password))
                return Unauthorized();

            return Ok("some access token");
        }
    }
}