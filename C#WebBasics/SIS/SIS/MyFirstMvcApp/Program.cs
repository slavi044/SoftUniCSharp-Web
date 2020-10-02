namespace MyFirstMvcApp
{
    using MWS.HTTP;

    using System;
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();
            
            server.AddRoute("/", HomePage);
            server.AddRoute("/favicon,ico", Favicon);
            server.AddRoute("/about", About);
            server.AddRoute("/about/users/login", Login);

            await server.StartAsync(80);
        }

        private static HttpResponse Favicon(HttpRequest arg)
        {
            throw new NotImplementedException();
        }

        private static HttpResponse HomePage(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        private static HttpResponse About(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        private static HttpResponse Login(HttpRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
