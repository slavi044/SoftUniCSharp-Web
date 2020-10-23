using MySuls.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace MySuls.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemService problemService;

        public ProblemsController(IProblemService problemService)
        {
            this.problemService = problemService;
        } 

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, ushort points)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(name) || name.Length < 5 || name.Length > 20)
            {
                return this.Error("Name should be between 5 and 20 characters.");
            }

            if (points < 50 || points > 300)
            {
                return this.Error("Points should be between 50 and 300.");
            }

            this.problemService.Create(name, points);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.problemService.GetById(id);
            return this.View(viewModel);
        }
    }
}
