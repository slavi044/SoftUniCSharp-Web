using SUS.HTTP;
using SUS.MvcFramework;

namespace SulsExamPrep.Cotrollers
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
