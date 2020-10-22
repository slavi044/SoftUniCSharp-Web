using SUS.HTTP;
using SUS.MvcFramework;

namespace MySuls.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}
