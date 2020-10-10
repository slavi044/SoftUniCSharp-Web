﻿namespace MyFirstMvcApp.Controllers
{
    using MyFirstMvcApp.ViewModels;
    
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index(HttpRequest request)
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.CurrentYear = DateTime.Now.Year;
            viewModel.Message = "Welcome to Batlecards!";

            return this.View(viewModel);
        }

        public HttpResponse About(HttpRequest request)
        {
            return this.View();
        }
    }
}
