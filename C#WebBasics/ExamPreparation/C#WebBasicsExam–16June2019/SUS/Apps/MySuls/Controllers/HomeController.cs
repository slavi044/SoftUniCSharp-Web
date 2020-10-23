using MySuls.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace MySuls.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemService problemService;

        public HomeController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                return this.View(this.problemService.GetAll(), "IndexLoggedIn"); 
            }
            return this.View();
        }
    }
}
