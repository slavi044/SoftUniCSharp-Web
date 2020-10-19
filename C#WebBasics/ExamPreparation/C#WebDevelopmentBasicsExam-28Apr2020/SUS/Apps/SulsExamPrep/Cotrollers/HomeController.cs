using SulsExamPrep.Services;
using SulsExamPrep.ViewModels.Problems;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace SulsExamPrep.Cotrollers
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
                var viewModel = this.problemService.GetAll();
                return this.View(viewModel, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}
