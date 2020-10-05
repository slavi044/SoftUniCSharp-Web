namespace MyFirstMvcApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    using System.Text;

    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            string responseHtml = "<h1>Login...</h1>";
            byte[] responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            HttpResponse response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        public HttpResponse Register(HttpRequest request)
        {
            string responseHtml = "<h1>Register...</h1>";
            byte[] responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            HttpResponse response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
