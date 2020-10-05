namespace MyFirstMvcApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using System.IO;

    public class StaticFilesController : Controller
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            byte[] fileBytes = File.ReadAllBytes("wwwroot/favicon.ico");
            HttpResponse response = new HttpResponse("image/vnd.microsoft.icon", fileBytes);

            return response;
        }
    }
}
