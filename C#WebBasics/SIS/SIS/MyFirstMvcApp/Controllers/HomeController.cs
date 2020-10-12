namespace MyFirstMvcApp.Controllers
{
    using MyFirstMvcApp.ViewModels;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.CurrentYear = DateTime.UtcNow.Year;
            viewModel.Message = "Welcome to Battle Cards";
            if (this.Request.Session.ContainsKey("about"))
            {
                viewModel.Message += " YOU WERE ON THE ABOUT PAGE!";
            }

            return this.View(viewModel);
        }

        // GET /home/about
        public HttpResponse About()
        {
            this.Request.Session["about"] = "yes";
            return this.View();
        }
    }
}