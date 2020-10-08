namespace MyFirstMvcApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;
    using System.IO;

    public class StaticFilesController : Controller
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            return this.File("wwwroot/favicon.ico", "image/vnd.microsoft.icon");
        }

        public HttpResponse BootstrapJs(HttpRequest request)
        {
            return this.File("wwwroot/js/bootstrap.bundle.min.js", "text/javascript");
        }

        internal HttpResponse BootstrapCss(HttpRequest request)
        {
            return this.File("wwwroot/css/bootstrap.min.css", "text/css");
        }

        internal HttpResponse CustomCss(HttpRequest request)
        {
            return this.File("wwwroot/css/custom.css", "text/css"); ;
        }

        internal HttpResponse CustomJs(HttpRequest request)
        {
            return this.File("wwwroot/js/custom.js", "text/javascript");
        }
    }
}