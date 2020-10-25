using Git.Services;
using Git.ViewModels.Commits;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly IRepositoriesService repositoriesService;
        private readonly IUsersService usersService;
        private readonly ICommitsService commitsService;

        public CommitsController(IRepositoriesService repositoriesService, IUsersService usersService, ICommitsService commitsService)
        {
            this.repositoriesService = repositoriesService;
            this.usersService = usersService;
            this.commitsService = commitsService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            CommitViewModel viewModel = new CommitViewModel
            {
                Id = id,
                Name = this.repositoriesService.GetNameById(id)
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string description, string id)
        {
            if (description.Length < 5)
            {
                return this.Error("Invalid description");
            }

            string repId = this.repositoriesService.GetIdByName(id);
            string userId = this.GetUserId();
            this.commitsService.Create(description, userId, repId);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse All()
        {
            return this.View();
        }
    }
}
