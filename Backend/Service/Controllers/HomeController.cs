using System.Web.Http;

namespace Service.Controllers
{
    [Authorize]
    public class HomeController : ApiController
    {
        public string Get()
        {
            return $"It Works! This is the home for user: {User.Identity.Name}, is admin: {User.IsInRole("admin")}";
        }
    }
}