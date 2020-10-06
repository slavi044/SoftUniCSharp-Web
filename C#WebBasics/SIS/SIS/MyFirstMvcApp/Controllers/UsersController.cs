namespace MyFirstMvcApp.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse Register(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse DoLogin(HttpRequest request)
        {
            //TODO: Implement

            return this.Redirect("/");
        }
    }
}
