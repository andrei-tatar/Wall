using System.Threading.Tasks;
using System.Web.Http;
using Service.Models;

namespace Service.Controllers
{
    public class TestController : ApiController
    {
        public async Task<TestModel> Get()
        {
            await Task.Delay(2000); //it takes a while to load

            return new TestModel { Name = "Test", Description = "It works!" };
        }
    }
}
