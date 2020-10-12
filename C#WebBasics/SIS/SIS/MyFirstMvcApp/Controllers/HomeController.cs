namespace MyFirstMvcApp.Controllers
{
    using Microsoft.EntityFrameworkCore;
    using MyFirstMvcApp.ViewModels;
    
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.CurrentYear = DateTime.UtcNow.Year;
            viewModel.Message = "Welcome to Battle Cards";

            return this.View(viewModel);
        }

        // GET /home/about
        public HttpResponse About()
        {
            return this.View();
        }
    }
}
