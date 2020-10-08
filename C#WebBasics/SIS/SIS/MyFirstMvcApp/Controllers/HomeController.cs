namespace MyFirstMvcApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System.Linq;
    using System.Text;

    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            return this.View();
        }
    }
}
