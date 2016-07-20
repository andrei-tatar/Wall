using System.ComponentModel.Composition;
using System.Web.Http;

namespace Service.Controllers
{
    [Authorize]
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class HomeController : ApiController
    {
        public string Get()
        {
            return $"It Works! This is the home for user: {User.Identity.Name}, is admin: {User.IsInRole("admin")}";
        }
    }
}