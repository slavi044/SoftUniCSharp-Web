using SulsExamPrep.Services;
using SulsExamPrep.ViewModels.Submission;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SulsExamPrep.Cotrollers
{
    public class SubmissionsController : Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionService submissionService;

        public SubmissionsController(IProblemService problemService, ISubmissionService submissionService)
        {
            this.problemService = problemService;
            this.submissionService = submissionService;
        }

        public HttpResponse Create(string id)
        {
            var viewModel = new CreateViewModel
            {
                ProblemId = id,
                Name = this.problemService.GetNameById(id)
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (string.IsNullOrEmpty(code) || code.Length < 30 || code.Length > 800)
            {
                return this.Error("Code should be between 30 and 800 characters long.");
            }

            string userId = this.GetUserId();
            this.submissionService.Create(problemId, userId, code);

            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            this.submissionService.Delete(id);

            return this.Redirect("/");
        }
    }
}
