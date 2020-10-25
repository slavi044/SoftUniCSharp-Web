using Git.Data;
using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;
        private readonly IUsersService usersService;

        public RepositoriesController(IRepositoriesService repositoriesService, IUsersService usersService)
        {
            this.repositoriesService = repositoriesService;
            this.usersService = usersService;
        }

        public HttpResponse All()
        {
            var viewModel = this.repositoriesService.GetAll(); 

            return this.View(viewModel);
        }

        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, string repositoryType)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 10)
            {
                return this.Error("Invalid name");
            }

            bool isPublic = false;
            if (repositoryType == "Public")
            {
                isPublic = true;
            }

            string userId = this.GetUserId();

            repositoriesService.Create(name, isPublic, userId);

            return Redirect("/Repositories/All");
        }
    }
}
