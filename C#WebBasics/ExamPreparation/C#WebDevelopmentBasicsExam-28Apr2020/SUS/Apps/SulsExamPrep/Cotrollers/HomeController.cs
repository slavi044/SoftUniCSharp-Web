using SulsExamPrep.ViewModels.Problems;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace SulsExamPrep.Cotrollers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                return this.View(new List<HomePageProblemViewModel>(), "IndexLoggedIn");
            }

            return this.View();
        }
    }
}
